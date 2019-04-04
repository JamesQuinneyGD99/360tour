using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QUI16000158
// James Quinney
public class CameraRaycaster : MonoBehaviour
{
    POIButton POILookingAt;
    GUIButton GUILookingAt;

    void Update(){
        RaycastHit hit; // This is where we store out hit data from the raycast
        // We shoot a raycast forward from the camera
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, Mathf.Infinity)){
            // We check to see if we hit a point of interest button
            if(hit.collider.gameObject.tag == "POIButton"){
                POIButton curButton = hit.collider.gameObject.GetComponent<POIButton>(); // We store the button for ease of access
                
                // We check to see if the button isn't already in our view
                if(!curButton.inView){
                    curButton.inView = true; // We tell the button we are looking at it
                    curButton.OnHoverEnter(); // We tell the button we have just hovered over it
                    // We check to see if we were just looking at a different button
                    if(POILookingAt){
                        POILookingAt.OnHoverExit(); // We tell that button we just hovered off of it
                        POILookingAt.inView = false; // We tell the button that it is no longer in view
                    }
                    POILookingAt = curButton; // We tell the camera which button it's looking at
                }
            }
            // We check to see if the player is looking at a GUI button
            if(hit.collider.gameObject.tag == "GUIButton"){
                GUIButton curButton = hit.collider.gameObject.GetComponent<GUIButton>(); // We cache the button to use it later
                
                // We ensure the button isn't already looked at
                if(!curButton.inView){
                    curButton.inView = true; // We tell the button it is now being looked at
                    curButton.OnHoverEnter(); // We tell the button we have just hovered over it
                    // We check to see if we were just looking at a different button
                    if(GUILookingAt){
                        GUILookingAt.OnHoverExit(); // We tell the other button we hovered off of it
                        GUILookingAt.inView = false; // We tell the other button that it is no longer in view
                    }
                    GUILookingAt = curButton; // We tell the camera we are now looking at this button
                }
            }
        }
        // We check to see if the camera can't see anything
        else{
            
            // We check to see if we were looking at a POI button
            if(POILookingAt){
                POILookingAt.OnHoverExit(); // We tell the button we are no longer looking at it
                POILookingAt.inView = false; // We tell the button it has left the centre of our view
                POILookingAt = null; // We are no longer looking at any buttons
            }

            // We check to see if we were looking at any GUI buttons
            if(GUILookingAt){
                GUILookingAt.OnHoverExit(); // We tell the GUI button we aren't looking at it anymore
                GUILookingAt.inView = false; // We also tell it that it has left our view
                GUILookingAt = null; // We are no longer looking at any GUI buttons
            }
        }
    }
}
