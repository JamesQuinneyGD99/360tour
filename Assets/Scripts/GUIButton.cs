using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// QUI16000158
// James Quinney
public class GUIButton : MonoBehaviour
{
    public bool inView; // Whether this button is currently being looked at
    [SerializeField]
    GameObject other; // This is for zoom, disables the other button
    public static List<GameObject> GUIButtons;
    public static List<GameObject> lists;

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
    }

    // When the centre of the player's view enters the button
    public void OnHoverEnter(){
        if(GetComponent<Button>().interactable){
            PointCircleLoad.hoverTime = Time.time; // We make it so the circle will be filled in 1 second
        }
    }
    
    // When the centre of the player's view exits the button
    public void OnHoverExit(){
        PointCircleLoad.hoverTime = 0.0f;
    }

    void OnHoverComplete(){
        if(transform.parent.gameObject.name == "List"){
            transform.parent.gameObject.SetActive(false);
        }

        switch(gameObject.name){
            case "Rooms":
                other.SetActive(!other.activeSelf);
                break;
            case "Options":
                other.SetActive(!other.activeSelf);
                break;
            case "Return":
                
                break;
            case "Zoom+":
                Camera.main.GetComponent<Camera>().fieldOfView = 30.0f;
                gameObject.SetActive(false);
                other.SetActive(true);
                break;
            case "Zoom-":
                Camera.main.GetComponent<Camera>().fieldOfView = 60.0f;
                other.SetActive(true);
                break;
            case "Accessibility":
                foreach(GameObject list in lists){
                    list.SetActive(true);
                }

                foreach(GameObject GUIButton in GUIButtons){
                    Text buttonText = GUIButton.GetComponentInChildren<Text>();
                    int fontSize = 20;
                    if(buttonText.fontSize == fontSize){
                        buttonText.fontSize = fontSize / 2;
                        Color defaultAlpha = GUIButton.GetComponent<Image>().color;
                        GUIButton.GetComponent<Image>().color = new Color(defaultAlpha.r,defaultAlpha.g,defaultAlpha.b,0.25f);
                    }
                    else{
                        buttonText.fontSize = fontSize;
                        Color defaultAlpha = GUIButton.GetComponent<Image>().color;
                        GUIButton.GetComponent<Image>().color = new Color(defaultAlpha.r,defaultAlpha.g,defaultAlpha.b,0.5f);
                    }
                }

                foreach(GameObject list in lists){
                    list.SetActive(false);
                }
                break;
            case "Colour":
                foreach(GameObject list in lists){
                    list.SetActive(true);
                }

                foreach(GameObject GUIButton in GUIButtons){
                    Color defaultColor = GUIButton.GetComponent<Image>().color;

                    if(defaultColor.b == 1.0f){
                        GUIButton.GetComponent<Image>().color = new Color(defaultColor.r,0.0f,0.0f,defaultColor.a);
                    }
                    else{
                        GUIButton.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,defaultColor.a);
                    }
                }

                foreach(GameObject list in lists){
                    list.SetActive(false);
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
