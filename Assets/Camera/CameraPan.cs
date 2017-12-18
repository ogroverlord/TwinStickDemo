using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CameraPan : MonoBehaviour {

    private const float distanceFromCamera = 10f; 
    private GameObject player;

    private GameObject stick;
    private float rotationSpeed = 0.5f;
    private float pitch;
    private float yaw; 


	void Start () {
        yaw = transform.rotation.x;
        pitch = transform.rotation.y; 
        player = GameObject.FindGameObjectWithTag("Player");
        stick = GameObject.Find("selfie stick");

    }

    void LateUpdate()
    {


        stick.transform.position = player.transform.position;

        yaw += rotationSpeed * CrossPlatformInputManager.GetAxis("Mouse X");
        pitch -= rotationSpeed * CrossPlatformInputManager.GetAxis("Mouse Y");
 
        stick.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    
    }
}
