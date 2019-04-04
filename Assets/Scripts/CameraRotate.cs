using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// James Quinney
// QUI16000158
public class CameraRotate : MonoBehaviour
{
  float pitch;
  float yaw;

      // Start is called before the first frame update
      void Start()
      {
        Cursor.visible = false; // We make the mouse cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
      }

      // Update is called once per frame
      void Update()
      {
        yaw += Input.GetAxis("Mouse X"); // We increase the player's yaw rotation by their mouse movement along the X axis
        pitch -= Input.GetAxis("Mouse Y"); // We increase the player's pitch rotation by their mouse movement along the Y axis

        transform.eulerAngles = new Vector3(pitch,yaw,0.0f); // We update the camera's rotation
      }
}
