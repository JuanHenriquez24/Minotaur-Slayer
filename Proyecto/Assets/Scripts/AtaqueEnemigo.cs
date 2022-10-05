using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtaqueEnemigo : MonoBehaviour
{
    [SerializeField] private float hpMax;
    private float hpActual;
    [SerializeField] private float danio;
    private float timer_DamageCoolDown;
    [SerializeField] private float damageCoolDownTime;
    private bool playing;
    private Rigidbody rb;
    private float timer_attackCoolDown;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackTime;
    private Transform player;
    private Transform parent;
    private NavMeshAgent agent;
    private float timer = 20;
    [SerializeField] private Color colorDanio;
    private Color ogColor;

    void Start()
    {
        ogColor = GetComponent<MeshRenderer>().material.color;
        agent = GetComponent<NavMeshAgent>();
        parent = gameObject.transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).tag == "PLAYER")
            {
                player = parent.GetChild(i);
                break;
            }
        }
        rb = gameObject.GetComponent<Rigidbody>();
        hpActual = hpMax;
        timer_DamageCoolDown = damageCoolDownTime;
        attackCoolDown += attackTime;
        timer_attackCoolDown = attackCoolDown;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            timer_DamageCoolDown += Time.deltaTime;
            timer_attackCoolDown += Time.deltaTime;

            
            
            timer += Time.deltaTime;
            if(timer > 0.5 && timer < 10)
            {
                rb.isKinematic = true;
                agent.enabled = true;
                timer = 10;
                GetComponent<MeshRenderer>().material.color = ogColor;
                if (hpActual <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else if(timer > 10)
            {
                agent.destination = player.position;

            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "PLAYER" && timer_attackCoolDown > attackCoolDown)
        {
            player.GetComponent<PlayerController>().recibirDanio(danio);
        }

        if(col.tag == "ATTACK" && timer_DamageCoolDown > damageCoolDownTime)
        {
            float danioJugador = col.GetComponent<AtaqueJugador>().danio;
            hpActual -= danioJugador;
            timer_DamageCoolDown = 0;
            agent.enabled = false;
            rb.isKinematic = false;
            rb.AddRelativeForce(new Vector3(0, 100, -100));
            GetComponent<MeshRenderer>().material.color = colorDanio;
            timer = 0;
            Debug.Log("hit");
        }
    }
}
