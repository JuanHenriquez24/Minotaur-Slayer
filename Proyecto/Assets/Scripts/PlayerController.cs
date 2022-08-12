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
    private float timer_run;
    [SerializeField] private float run_cool_down;
    [SerializeField] private float run_time;
    private float run_cool_down_timer;
    private bool is_running;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playing = gameObject.GetComponentInParent<Playing>().playing;
        run_cool_down_timer = run_cool_down;
        speed = walk_speed;
    }
    e
    private void Update()
    {
        if (is_running)
        {
            timer_run += Time.deltaTime;
        }
        else
        {
            run_cool_down_timer += Time.deltaTime;
        }
        if (playing)
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
            if (Input.GetKeyDown(KeyCode.E) && timer_run < run_time && run_cool_down_timer > run_cool_down && !is_running)
            {
                speed = run_speed;
                is_running = true;
                run_cool_down_timer = 0;
            }
            else if (Input.GetKeyDown(KeyCode.E) && is_running)
            {
                speed = walk_speed;
                is_running = false;
                timer_run = 0;
            }
            else if(timer_run > run_time && is_running)
            {
                speed = walk_speed;
                is_running = false;
                timer_run = 0;
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
