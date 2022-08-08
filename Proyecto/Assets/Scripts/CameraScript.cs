using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private Camera cam;

    public void Update()
    {
        //rotate on x
        float mouse_Y = Input.GetAxis("Mouse Y");
        mouse_Y = Mathf.Clamp(mouse_Y, -80, 80);
        transform.Rotate(new Vector3(-mouse_Y * sensitivity, 0, 0));
    }
}