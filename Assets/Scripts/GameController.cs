using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
public enum GameType { Normal,SpeedRun}
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameType gametype;
    private void Awake ()   
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad (gameObject);

        }
        else
        {
            Destroy (gameObject);
        }
    }


    // Sets the game type from our selections
    public void SetGameType (GameType _gametype)

    {
        gametype = _gametype;
    }
    // To toggle between speedrun on or off 
    public void ToggleSpeedRun(bool _speedRun)
    {
        if (_speedRun)
            SetGameType(GameType.SpeedRun);
        else 
            SetGameType (GameType.Normal);

    }
}
