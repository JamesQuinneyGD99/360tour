using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QUI16000158
// James Quinney
public class POIButton : MonoBehaviour
{
    public bool inView; // Whether this button is currently being looked at

    // When the centre of the player's view enters the button
    public void OnHoverEnter(){
        PointCircleLoad.hoverTime = Time.time; // We make it so the circle will be filled in 1 second
    }
    
    // When the centre of the player's view exits the button
    public void OnHoverExit(){
        PointCircleLoad.hoverTime = 0.0f; // Reset the circle
    }

    void OnHoverComplete(){
        // We check the name of the button
        switch(gameObject.name){
            
            default:
                break;
        }
    }

    void Update(){
        // We check to make sure the circle is in view, and hasn't already been clicked
        if(inView && PointCircleLoad.hoverTime != 0.0f){
            // We check if the circle is full
            if(Time.time - PointCircleLoad.hoverTime >= 1.0f){
                PointCircleLoad.hoverTime = 0.0f; // We reset the circle
                OnHoverComplete(); // Well the button the circle has filled
            }
        }
    }
}
