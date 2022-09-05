using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

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
    public float HPmax;
    public float HPActual;
    public float mouse_X;
    public float y_rot;
    private bool jumping;
    private float damage_cool_down;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        run_cool_down_timer = run_cool_down;
        speed = walk_speed;
        HPActual = HPmax;
        damage_cool_down = 5;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            //rotate on y
            mouse_X = Input.GetAxis("Mouse X");
            y_rot += mouse_X * sensitivity;

            transform.rotation = Quaternion.Euler(0, y_rot, 0);

            //walk
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -speed);
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
            if (is_running)
            {
                timer_run += Time.deltaTime;
                speed = run_speed;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    is_running = false;
                }
                else if (timer_run > run_time)
                {
                    is_running = false;
                    run_cool_down_timer = 0;
                }
            }
            else
            {
                run_cool_down_timer += Time.deltaTime;
                speed = walk_speed;
                if (Input.GetKeyDown(KeyCode.E) && run_cool_down_timer > run_cool_down)
                {
                    is_running = true;
                    timer_run = 0;
                }
            }

            //jump
            if (on_floor && Input.GetKey(KeyCode.Space) && !jumping)
            {
                PlayerJump();
            }

            //damage cool down
            damage_cool_down += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PISO")
        {
            on_floor = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "PISO")
        {
            on_floor = false;
            jumping = false;
        }
    }
    
    private void OnCollisionStay(Collision col)
    {
        if(col.collider.tag == "PAIN" && damage_cool_down > 0.5)
        {
            HPActual -= 10;
            damage_cool_down = 0;
        }
    }

    private void PlayerJump()
    {
        rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        jumping = true;
    }
}
