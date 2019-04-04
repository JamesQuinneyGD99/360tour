using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Student Name: Nicholas Easterby
//Student Number: EAS12337350
public class PointCircleLoad : MonoBehaviour
{
    Image circle;//Image of the cicle to represent loading
    public static float hoverTime;//Variable to store amount of time spent hovering over image
    public float waitTime;//Variable to hold amount of time necessary for action to occur

	// Use this for initialization
	void Start ()
    {
        circle = GetComponent<Image>();//Gets the image that this script is attached to
        circle.fillClockwise = true;//Sets the fill type to clockwise
        hoverTime = 0.0f; // We set our hover time to a high number
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (waitTime != 0 && hoverTime != 0)
        {//Checks if dividing by zero
            float curTime = Time.time - hoverTime;
            curTime = Mathf.Clamp(curTime, 0, waitTime);//Ensures that hover time does not become larger than wait time.
            circle.fillAmount = curTime / waitTime;//Fills the circle as a ratio of hover time divided by the wait time.
        }
        else{
            circle.fillAmount = 0.0f;
        }
	}
}
