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

    [SerializeField] private float terremotoDuracionBasic;
    private float terremotoDuracion;
    [SerializeField] private float shakeAmount;
    public bool shaking;
    private float shakeTimer;
    public float timerTerremoto;
    public float timeToTerremoto;
    private float oneOrTwo;

    private void Start()
    {
        terremotoDuracion = terremotoDuracionBasic;
        timeToTerremoto = Random.Range(60f, 300f);
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            timerTerremoto += Time.deltaTime;
            if (timerTerremoto >= timeToTerremoto)
            {
                StartTerrmoto(terremotoDuracionBasic);
                timerTerremoto = 0;
                timeToTerremoto = Random.Range(60f, 300f);
            }

            //rotate on x
            mouse_Y = Input.GetAxis("Mouse Y");
            x_rot += -mouse_Y * sensitivity;
            x_rot = Mathf.Clamp(x_rot, -60, 60);

            //rotate on y
            y_rot = gameObject.GetComponentInParent<PlayerController>().y_rot;

            transform.rotation = Quaternion.Euler(x_rot, y_rot, 0);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartTerrmoto(10f);
        }

    }

    void LateUpdate()
    {
        //camera follow
        cam.transform.rotation = transform.rotation;
        
        if (!shaking)
        {
            cam.transform.position = transform.position;
        }
        else
        {
            shakeTimer += Time.deltaTime;
            if (shakeTimer > terremotoDuracion)
            {
                shaking = false;
            }
            else if(oneOrTwo >= 3)
            {
                Vector2 cirlce = Random.insideUnitCircle * shakeAmount;
                cam.transform.position = transform.position + new Vector3(cirlce.x, cirlce.y, 0);
                terremotoDuracion = terremotoDuracionBasic;
                oneOrTwo = 0;
            }
            else if(oneOrTwo > 0)
            {
                cam.transform.position = transform.position;
                oneOrTwo++;
            }
            else
            {
                oneOrTwo++;
            }

        }
    }

    public void StartTerrmoto(float time)
    {
        shaking = true;
        shakeTimer = 0;
        terremotoDuracion = time;
    }
}