using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//EAS12337350   
//Nicholas Easterby
//This script is used to create the data for the rooms. This includes the vector coordinates for the points and the associated text
public class RoomData : MonoBehaviour
{
    public Dictionary<Vector3, string>[] information;
    public VideoClip[] videos = new VideoClip[4];
    public AudioClip[] audioClips = new AudioClip[4];

    public GameObject textPanel;

    public static Dictionary<string, Room> rooms;

    //Loads in all the data for the points on interest.
    private void Start()
    {
        information = new Dictionary<Vector3, string>[4];

        information[0] = new Dictionary<Vector3, string>();
        information[0].Add(new Vector3(0, 0, 0), "In room B408 there are 3 workstations with 5 desktop computers on each workstation. These run off their own network with higher speeds");
        information[0].Add(new Vector3(0, 0, 0), "In the corner of the room there are 2 sensors for the VR headset HTC VIVE");
        information[0].Add(new Vector3(0, 0, 0), "The Games Design and VR Course is the only lesson taught in B408");

        rooms = new Dictionary<string, Room>();
    }
}