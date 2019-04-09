using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

//EAS12337350   
//Nicholas Easterby
//This script holds the constructor for each room which will use the room data to provide the points of interest.
public class Room
{
    Dictionary<Vector3, string> pointsOfInterest;//List of points in the room and the accompanying text
    VideoClip roomVideo;//The video for the room
    AudioClip roomVoiceOver;//The audio for the room

    public GameObject textPanel;//Prefab object containing panel and text attached

    //VideoSphereScript videoSphere;

    //constructor for the room, taking a dictionary, a video clip and an audio clip
    public Room(Dictionary<Vector3,string> roomData, VideoClip roomClip, AudioClip roomAudio)
    {
        pointsOfInterest = roomData;
        roomVideo = roomClip;
        roomVoiceOver = roomAudio;//Loads in the correct information

        //videoSphere = FindObjectOfType<VideoSphereScript>();
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

    public void PlayVoice()
    {

    }
}
