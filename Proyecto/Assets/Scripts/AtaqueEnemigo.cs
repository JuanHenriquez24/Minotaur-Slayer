using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] private float hpMax;
    public float hpActual;
    public float danio;
    public float timer_DamageCoolDown;
    [SerializeField] private float damageCoolDownTime;
    private bool playing;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        hpActual = hpMax;
        timer_DamageCoolDown = damageCoolDownTime;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            timer_DamageCoolDown += Time.deltaTime;
            if (hpActual <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "ATTACK" && timer_DamageCoolDown > damageCoolDownTime)
        {
            rb.AddForce(new Vector3(0f, 0f, -2f));
            float danioJugador = col.GetComponent<AtaqueJugador>().danio;
            hpActual -= danioJugador;
            timer_DamageCoolDown = 0;
        }
    }
}
