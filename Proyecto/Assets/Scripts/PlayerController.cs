using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

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
    [SerializeField] private float damageCoolDownTime;
    [SerializeField] private Image damageOverlay;
    private bool damaging = false;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackForceUP;
    [SerializeField] private GameObject sceneManager;
    private Vector3 newPosition;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        run_cool_down_timer = run_cool_down;
        speed = walk_speed;
        HPActual = HPmax;
        damage_cool_down = damageCoolDownTime;
        transform.position = new Vector3(-77.7f, 3f, -26.21f);
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
            newPosition = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                newPosition += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                newPosition -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                newPosition += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                newPosition -= transform.right * speed * Time.deltaTime;
            }
            rb.MovePosition(transform.position + newPosition);

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

            if(damage_cool_down > 0.3 && damaging)
            {
                damageOverlay.enabled = false;
                damaging = false;
            }

            if(HPActual <= 0)
            {
                sceneManager.GetComponent<startEndLoseScreen>().loseGame();
            }
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
        if (col.tag == "PISO")
        {
            on_floor = false;
            jumping = false;
        }
    }
    
    private void PlayerJump()
    {
        rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        jumping = true;
    }

    public void recibirDanio(float danio, GameObject enemy)
    {
        if(damage_cool_down > damageCoolDownTime)
        {
            HPActual -= danio;
            damage_cool_down = 0;
            Vector3 direction = (transform.position - enemy.transform.position).normalized;
            rb.AddForce(direction * knockbackForce);
            rb.AddRelativeForce(new Vector3(0, knockbackForceUP, 0));
            damageOverlay.enabled = true;
            damaging = true;
        }
    }
}
