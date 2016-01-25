using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Script used to make a circle sprite follow whatever planet is highlighted, udring the tutorial
public class Highlighter : MonoBehaviour
{
    public GameObject targetObject;         // Whatever object is being selected
    public Image selectionIcon;             // The sprite that we'll be making follow the planet
	
	// Update is called once per frame
	void Update ()
    {
        Follow();
	}

    // Used by the tutorial sequencer to choose the object that should be followed
    public void SetTarget(GameObject input)
    {
        if(input != null)                   // If there's an object...
        {
            targetObject = input;           // That's the target to follow
            selectionIcon.enabled = true;   // show the image
        }
            

        if (input == null)                  // If there's no object...
            targetObject = null;            // Hide the image
    }

    void Follow()
    {
        if (targetObject != null)         // If you've got something selected...
            selectionIcon.transform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position); // Make the selection icon follow the selected object

        else if (targetObject == null)    // If you don't have anything selected...
            selectionIcon.enabled = false;  // hide the selection icon
    }
}
