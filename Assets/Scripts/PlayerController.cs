using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public float speed = 10.0f;
    private Rigidbody rb;
    private int count;
    private int pickupCount;
    private Timer timer;
    private bool gameOver=false;
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour; 

    [Header("UI")]
    public GameObject inGamePanel;
    public GameObject gameOverPanel; 
    public TMP_Text countText;
    public TMP_Text timerText;
    public TMP_Text winTimeText;

    //Controllers 
    SoundController soundController;
    GameController gameController;
    CameraController cameraController;
    


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        //Get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        //Run the check pickups function
        SetCountText();
        //Get the timer object
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
        //Turn on our in game panel
        inGamePanel.SetActive(true);
        //Turn off our win panel 
        gameOverPanel.SetActive(false);
        resetPoint = GameObject.Find("Reset Point");
        originalColour = GetComponent<Renderer>().material.color;

        gameController = FindObjectOfType<GameController>();
        timer = FindObjectOfType<Timer>();
        if (gameController .gameType == GameType.SpeedRun)
            StartCoroutine(timer.StartCountdown()); 
        soundController = FindObjectOfType<SoundController>();
        cameraController = FindObjectOfType<CameraController>();

    }
    private void Update()
    {
        timerText.text = "Time" + timer.GetTime().ToString("F2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameController.gameType == GameType.SpeedRun && !timer.IsTiming())
            return;

        if (resetting)
        {
            return;
        }

        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        if (cameraController.cameraStyle == CameraStyle.Free)
        {
            //rotates the player to the direction of the camera
            transform.eulerAngles = Camera.main.transform.eulerAngles;
            //translates the input vectors into coordinates
            movement = transform. TransformDirection (movement);
        }
        rb.AddForce(movement * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
       if (collision.gameObject.CompareTag("Wall"))
        {
            soundController.PlayCollisionSound(collision.gameObject);
        }
    }

    public IEnumerator ResetPlayer ()
    {
        
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i<1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
        {
            other.GetComponent<Particles>().CreateParticles();
            Destroy (other.gameObject); 
            //Decroment the pickup count
            pickupCount-=1;
            //Run the check pickups function
            SetCountText();
            soundController.PlayPickupSound();
        }
    }
    void SetCountText()
    {
        //Display the amount of pickups left in our scene

        countText.text = "Count:" + count.ToString();
        if (count >= pickupCount)

        {
            gameOverPanel.SetActive(true);
            winTimeText.text = "You Win"; 

        }
    }
    void WinGame()
    {
        //Set game over to true
        gameOver = true;    
        //Stop the timer 
        timer.StopTimer ();
       //Turn on our win panel
       gameOverPanel.SetActive(true);    
      //turn off our game panel
      inGamePanel.SetActive (false);
        // Display the timer on the win time text
        winTimeText.text = "Your time was:" + timer.GetTime().ToString("F2");
        soundController.PlayWinSound();

        //Set the velocity of the rigidbody to zero

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (gameController.gameType == GameType.SpeedRun)
            timer.StopTimer();

       
       

    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    { 
        Application.Quit();
    }
        
}
