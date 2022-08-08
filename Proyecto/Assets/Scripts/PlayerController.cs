using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walk_speed;
    [SerializeField] private Camera cam;
    [SerializeField] private float sensitivity = 4f;

    private void Start()
    {
    }

    private void Update()
    {
        //camera follow
        cam.transform.rotation = transform.rotation;
        cam.transform.position = transform.position;

        //rotate on y
        float mouse_X = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouse_X * sensitivity, 0);

        //walk
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walk_speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walk_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walk_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walk_speed, 0, 0);
        }
    }
}
