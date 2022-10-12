using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Camera cam;
    private float x_rot;
    private float y_rot;
    private bool playing;
    private float mouse_Y;


    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            //rotate on x
            mouse_Y = Input.GetAxis("Mouse Y");
            x_rot += -mouse_Y * sensitivity;
            x_rot = Mathf.Clamp(x_rot, -60, 60);

            //rotate on y
            y_rot = gameObject.GetComponentInParent<PlayerController>().y_rot;

            transform.rotation = Quaternion.Euler(x_rot, y_rot, 0);

            //camera follow
            cam.transform.rotation = transform.rotation;
            cam.transform.position = transform.position;
        }
    }
    
    public void terrmoto()
    {
    }
}