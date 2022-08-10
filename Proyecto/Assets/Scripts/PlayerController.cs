using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walk_speed;
    [SerializeField] private float run_speed;
    private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jump_force;
    private Rigidbody rb;
    private bool playing;
    public bool on_floor;
    [SerializeField] private float timer_run;
    [SerializeField] private float run_cool_down;
    [SerializeField] private float run_time;
    [SerializeField] private float run_cool_down_timer;

    private void Update()
    {
        timer_run += Time.deltaTime;
        run_cool_down_timer += Time.deltaTime;
        rb = gameObject.GetComponent<Rigidbody>();
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if(playing)
        {
            //rotate on y
            float mouse_X = Input.GetAxis("Mouse X");
            transform.Rotate(0, mouse_X * sensitivity, 0);

            //walk
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed, 0, 0);
            }

            //run
            if (Input.GetKeyDown(KeyCode.E))
            {
                timer_run = 0;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                run_cool_down_timer = 0;
            }
            if (Input.GetKey(KeyCode.E) && timer_run < run_time && run_cool_down_timer > run_cool_down)
            {
                speed = run_speed;
            }
            else
            {
                speed = walk_speed;
            }

            //jump
            if(on_floor && Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
                on_floor = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PISO")
        {
            on_floor = true;
        }
    }
}
