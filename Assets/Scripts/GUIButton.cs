using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// QUI16000158
// James Quinney
public class GUIButton : MonoBehaviour
{
    public bool inView; // Whether this button is currently being looked at
    [SerializeField]
    GameObject other; // This is for zoom, disables the other button, This is also used to load rooms
    public static List<GameObject> GUIButtons; // This is all of the buttons in the scene
    public static List<GameObject> lists; // This is all of the lists in the scene

    [SerializeField]
    VideoClip loadOnComplete; // This is the video clip that loads when the button is pressed
    [SerializeField]
    GameObject room; // This is the room that loads when the video completes
    VideoPlayer videoPlayer;

    void Start(){
        if(GUIButtons == null){
            GUIButtons = new List<GameObject>();
            lists = new List<GameObject>();

            foreach(GameObject GUIButton in GameObject.FindGameObjectsWithTag("GUIButton")){
                GUIButtons.Add(GUIButton);
            }

            foreach(GameObject list in GameObject.FindGameObjectsWithTag("List")){
                lists.Add(list);
                list.SetActive(false);
            }
        }

        videoPlayer = GameObject.Find("Sphere").GetComponent<VideoPlayer>(); // We find the video player
    }

    // When the centre of the player's view enters the button
    public void OnHoverEnter(){
        if(GetComponent<Button>().interactable){
            PointCircleLoad.hoverTime = Time.time; // We make it so the circle will be filled in 1 second
        }
    }
    
    // When the centre of the player's view exits the button
    public void OnHoverExit(){
        PointCircleLoad.hoverTime = 0.0f; // Reset the circle
    }

    void OnHoverComplete(){
        // We check to see if the button is part of a list
        if(transform.parent.gameObject.name == "List"){
            transform.parent.gameObject.SetActive(false); // We hide the list
        }

        // We check which button it is 
        switch(gameObject.name){
            case "Rooms":
                other.SetActive(!other.activeSelf); // We toggle the room list
                break;
            case "Options":
                other.SetActive(!other.activeSelf); // We toggle the options list
                break;
            case "Return":
                
                break;
            case "Zoom+":
                Camera.main.GetComponent<Camera>().fieldOfView = 30.0f; // We zoom in
                gameObject.SetActive(false); // We hide the zoom in button 
                other.SetActive(true); // We make the zoom out button visible
                break;
            case "Zoom-":
                Camera.main.GetComponent<Camera>().fieldOfView = 60.0f; // We reset the zoom
                other.SetActive(true); // We make the zoom in button visible
                break;
            case "Accessibility":
                // We make all lists active so we can modify the buttons
                foreach(GameObject list in lists){
                    list.SetActive(true);
                }

                // We loop through each button
                foreach(GameObject GUIButton in GUIButtons){
                    Text buttonText = GUIButton.GetComponentInChildren<Text>(); // We find the text attached to the button
                    int fontSize = 20; // The enlarged font size
                    // We check if the text is currently enlarged
                    if(buttonText.fontSize == fontSize){
                        buttonText.fontSize = fontSize / 2; // We make the text smaller
                        Color defaultAlpha = GUIButton.GetComponent<Image>().color; // We get the colour of the button
                        GUIButton.GetComponent<Image>().color = new Color(defaultAlpha.r,defaultAlpha.g,defaultAlpha.b,0.25f); // We make the it more transparent
                    }
                    // If the text isn't enlarged
                    else{
                        buttonText.fontSize = fontSize; // We enlarge the text
                        Color defaultAlpha = GUIButton.GetComponent<Image>().color; // We get the colour of the button
                        GUIButton.GetComponent<Image>().color = new Color(defaultAlpha.r,defaultAlpha.g,defaultAlpha.b,0.5f); // We make it less transparent
                    }
                }

                // We deactivate the lists again
                foreach(GameObject list in lists){
                    list.SetActive(false);
                }
                break;
            case "Colour":
                // We activate the lists so we can edit their buttons
                foreach(GameObject list in lists){
                    list.SetActive(true);
                }

                // We loop through each button
                foreach(GameObject GUIButton in GUIButtons){
                    Color defaultColor = GUIButton.GetComponent<Image>().color; // We store their current colour

                    // We check to see if the button is the default colour
                    if(defaultColor.b == 1.0f){
                        GUIButton.GetComponent<Image>().color = new Color(defaultColor.r,0.0f,0.0f,defaultColor.a); // We make the button red
                    }
                    // We check if the button is currently red
                    else{
                        GUIButton.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,defaultColor.a); // We reset the button colour
                    }
                }

                // We deactivate the lists again 
                foreach(GameObject list in lists){
                    list.SetActive(false);
                }
                break;
            case "B408":
                // We check if this buttons loads a video
                if(loadOnComplete != null){
                    Destroy(Room.currentRoom); // We get rid of the old room
                    Room.currentRoom = Instantiate(room,new Vector3(0,0,0),Quaternion.identity); // We add the new room
                    Room.currentRoom.GetComponent<Room>().textPanel = Room.currentRoom.transform.Find("POICanvas").gameObject; // We store the canvas for the other room
                    Room.currentRoom.transform.Find("POICanvas").gameObject.SetActive(false); // We hide the buttons in the new room
                    videoPlayer.clip = loadOnComplete; // Load our video in
                    videoPlayer.playbackSpeed = 100.0f; // Reset the playback speed;
                    videoPlayer.Play(); // Start the video
                }
                break;
            case "Outside":
                // We check if this buttons loads a video
                if(loadOnComplete != null){
                    Destroy(Room.currentRoom); // We get rid of the old room
                    Room.currentRoom = Instantiate(room,new Vector3(0,0,0),Quaternion.identity); // We add the new room
                    Room.currentRoom.GetComponent<Room>().textPanel = Room.currentRoom.transform.Find("POICanvas").gameObject; // We store the canvas for the other room
                    Room.currentRoom.transform.Find("POICanvas").gameObject.SetActive(false); // We hide the buttons in the new room
                    videoPlayer.clip = loadOnComplete; // Load our video in
                    videoPlayer.playbackSpeed = 100.0f; // Reset the playback speed;
                    videoPlayer.Play(); // Start the video
                }
                break;
            default:
                break;
        }
    }

    void Update(){
        // We check to see if we are hovering over the button
        if(inView && PointCircleLoad.hoverTime != 0.0f){
            // We check to see if the circle is fully filled
            if(Time.time - PointCircleLoad.hoverTime >= 1.0f){
                PointCircleLoad.hoverTime = 0.0f; // Remove the loading circle
                OnHoverComplete(); // We tell the button it is filled
            }
        }
    }
}
