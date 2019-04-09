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
        PointCircleLoad.hoverTime = 0.0f;
    }

    void OnHoverComplete(){
        
    }

    void Update(){
        if(inView && PointCircleLoad.hoverTime != 0.0f){
            if(Time.time - PointCircleLoad.hoverTime >= 1.0f){
                PointCircleLoad.hoverTime = 0.0f;
                OnHoverComplete();
            }
        }
    }
}
