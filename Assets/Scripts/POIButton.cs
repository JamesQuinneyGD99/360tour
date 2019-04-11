using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// QUI16000158
// James Quinney
public class POIButton : MonoBehaviour
{
    public bool inView; // Whether this button is currently being looked at
    [SerializeField]
    VideoClip loadOnComplete; // This is the video that loads when you have finished hovering over the button
    [SerializeField]
    GameObject room; // This is the room that loads when the video completes
    VideoPlayer videoPlayer;

    void Start(){
        videoPlayer = GameObject.Find("Sphere").GetComponent<VideoPlayer>(); // We find the video player
    }

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

        // We check if this buttons loads a video
        if(loadOnComplete != null){
            Destroy(Room.currentRoom); // We get rid of the old room
            Room.currentRoom = Instantiate(room,new Vector3(0,0,0),Quaternion.identity); // We add the new room
            Room.currentRoom.GetComponent<Room>().textPanel = Room.currentRoom.transform.Find("POICanvas").gameObject; // We store the canvas for the other room
            Room.currentRoom.transform.Find("POICanvas").gameObject.SetActive(false); // We hide the buttons in the new room
            videoPlayer.clip = loadOnComplete; // Load our video in
            videoPlayer.Play(); // Start the video
            videoPlayer.playbackSpeed = 1.0f;
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
