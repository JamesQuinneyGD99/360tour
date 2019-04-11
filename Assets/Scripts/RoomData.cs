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

        information[1] = new Dictionary<Vector3, string>();
        information[1].Add(new Vector3(0, 0, 0), "The HE centre has a kitchen area for you to get hot drinks and prepare your food.");
        information[1].Add(new Vector3(0, 0, 0), "The He centre has some comfy chairs for you to chill out in during your breaks in lesson.");
        information[1].Add(new Vector3(0, 0, 0), "The HE centre has got many computers so you are able to do your work or chill out on during breaks.");

        information[2] = new Dictionary<Vector3, string>();
        information[2].Add(new Vector3(0, 0, 0), "D004 is the VR room at Solihull college. This room has all the latest technology related to VR. HTC VIVE, Oculus rifts and more.");
        information[2].Add(new Vector3(0, 0, 0), "D004 has many computers all with the capability of playing VR titles.");
        information[2].Add(new Vector3(0, 0, 0), "D004 also has a VR club every week that anyone at the college to attend.");

        information[3] = new Dictionary<Vector3, string>();
        information[3].Add(new Vector3(0, 0, 0), "B409 is a business studies room. This is a large room accommodating the business students classes.");
        information[3].Add(new Vector3(0, 0, 0), "B409 contains many computers that run the college network on virtual desktops.");
        information[3].Add(new Vector3(0, 0, 0), "B409 is a large space that is often used for meetings.");

        rooms = new Dictionary<string, Room>();
    }
}