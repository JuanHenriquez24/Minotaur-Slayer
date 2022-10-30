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
    [SerializeField] private Transform player;
    [SerializeField] private Transform parent;
    private NavMeshAgent agent;
    private float timer = 20;
    [SerializeField] private Color colorDanio;
    [SerializeField] private Material[] materiales;
    [SerializeField] private Color ogMaterialColor;
    private Animator anim;
    private bool playerInRange;
    [SerializeField] private GameObject hpPrefab;

    void Start()
    {
        anim = GetComponent<Animator>();
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
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "attack")
            {
                attackTime = clip.length;
            }
        }
        attackCoolDown += attackTime;
        timer_attackCoolDown = attackCoolDown;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            agent.isStopped = false;
            timer_DamageCoolDown += Time.deltaTime;
            timer_attackCoolDown += Time.deltaTime;
            
            timer += Time.deltaTime;
            if(timer > 0.5 && timer < 10)
            {
                for (int i = 0; i < materiales.Length; i++)
                {
                    materiales[i].color = ogMaterialColor;
                }
                rb.isKinematic = true;
                agent.enabled = true;
                timer = 10;
                if (hpActual <= 0)
                {
                    int cantHp = Random.Range(20, 30);
                    for (int i = 0; i < cantHp; i++)
                    {
                        Vector3 pos = new Vector3(Random.Range(-1f, 1.1f), 0, Random.Range(-1f, 1.1f));
                        GameObject hp = Instantiate(hpPrefab, transform.position + pos, transform.rotation);
                        hp.transform.parent = transform.parent;
                    }
                    Destroy(gameObject);
                }
            }
            else if(timer > 10)
            {
                agent.destination = player.position;
            }

            if (timer_attackCoolDown > attackTime)
            {
                anim.SetBool("atacar", false);
                agent.stoppingDistance = 0f;
            }
            else if (timer_attackCoolDown > 0.3 && timer_attackCoolDown < 0.4 && playerInRange)
            {
                player.GetComponent<PlayerController>().recibirDanio(danio, gameObject);
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "PLAYER" && timer_attackCoolDown > attackCoolDown)
        {
            anim.SetBool("atacar", true);
            agent.stoppingDistance = 1.6f;
            timer_attackCoolDown = 0;
        }

        if(col.tag == "ATTACK" && timer_DamageCoolDown > damageCoolDownTime)
        {
            float danioJugador = col.GetComponent<AtaqueJugador>().danio;
            hpActual -= danioJugador;
            timer_DamageCoolDown = 0;
            agent.enabled = false;
            rb.isKinematic = false;
            rb.AddRelativeForce(new Vector3(0, 100, -100));
            for (int i = 0; i < materiales.Length; i++)
            {
                materiales[i].color = colorDanio;
            }
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PLAYER")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "PLAYER")
        {
            playerInRange = false;
        }
    }
}
