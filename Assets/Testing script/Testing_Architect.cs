using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TESTING
{

    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        string[] lines = new string[5]
        {
            "What a wonderous night for frivolus Fun my pet.",
            "Let enjoy tonight's treats of sweet delights.",
            "Let us be gluttinous beast of the endless sky.",
            "Come and let us join the children in the festivities of hallows Night.",
           "and lest we come home empty handed."
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;

        }

        // Update is called once per frame
        void Update()
        {
            string longline = "come ye all ye children and follow the soudnds of merriment and fun and succumb to one's utmost desire and fear the light and surrend to the pleasure of darkness and the night.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();

                }
                else
                    architect.Build(longline);
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            
         

        }
    }
}
