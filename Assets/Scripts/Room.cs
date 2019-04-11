using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

//EAS12337350   
//Nicholas Easterby
//This script holds the constructor for each room which will use the room data to provide the points of interest.
public class Room : MonoBehaviour
{
    public Dictionary<Vector3, string> pointsOfInterest;//List of points in the room and the accompanying text
    public VideoClip roomVideo;//The video for the room

    public GameObject textPanel;//Prefab object containing panel and text attached

    public static GameObject currentRoom; // This is the current room

    GameObject videoSphere;

    //VideoSphereScript videoSphere;

    //constructor for the room, taking a dictionary and a video clip
    /*
    public Room(Dictionary<Vector3,string> roomData, VideoClip roomClip)
    {
        pointsOfInterest = roomData;
        roomVideo = roomClip;
        roomVoiceOver = roomAudio;//Loads in the correct information

        //videoSphere = FindObjectOfType<VideoSphereScript>();
    }
    */

    void Start(){
        videoSphere = GameObject.Find("Sphere");

        if(currentRoom == null){
            currentRoom = gameObject;
            videoSphere.GetComponent<VideoPlayer>().playbackSpeed = 100.0f;
        }
    }

    void Update(){
        if(!textPanel.activeSelf && videoSphere.GetComponent<VideoPlayer>().isPaused){
            textPanel.SetActive(true);
        }
    }
	
    //When called, makes the panel appear and changes the text accordingly
	public void DisplayInfo(Vector3 roomPosition, GameObject panel)
    {
        textPanel.SetActive(true);
        textPanel.GetComponentInChildren<Text>().text = pointsOfInterest[roomPosition];
    }
    
    //When called, makes the panel disappear
    public void ClosePanel()
    {
        textPanel.SetActive(false);
    }
}
