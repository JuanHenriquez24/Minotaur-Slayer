using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotauro : MonoBehaviour
{
    public int nextAttack;
    
    public float hpMax;
    public float hpActual;
    [SerializeField] private float danio;
    private float timer_DamageCoolDown;
    [SerializeField] private float damageCoolDownTime;
    private bool playing;
    private Rigidbody rb;
    private Transform player;
    private Transform parent;
    private float timer = 20;
    [SerializeField] private Color colorDanio;
    [SerializeField] private Material[] materiales;
    [SerializeField] private Color ogMaterialColor;
    private Animator anim;
    [SerializeField] private float knockbackForceUP;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float speed;
    private bool playerInRange = false;
    private float timerAtaque;
    private float attackTime;
    [SerializeField] private float terremotoTiempo;
    private float saltoTiempo;
    private float timerSalto;
    public float playerDistance;
    public bool[] hachaYterremotoAtaques = new bool[2];
    public bool contraPared = false;
    public float timerToNextAttack;
    public float timeToNextAttack;
    private float idleSpeed;
    [SerializeField] private float danioTerremoto;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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

        idleSpeed = speed;

        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "ataque")
            {
                attackTime = clip.length;
            }
            if(clip.name == "salto")
            {
                saltoTiempo = clip.length / 1.2f;
            }
        }
        timerAtaque = 1000;
        timerSalto = 1000;
        hachaYterremotoAtaques[0] = false;
        hachaYterremotoAtaques[1] = false;
        timeToNextAttack = Random.Range(5f, 10f);
        determineNextAttack();
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            anim.enabled = true;
            timerAtaque += Time.deltaTime;
            Vector3 targetPostition = new Vector3(player.position.x, this.transform.position.y, player.position.z);
            transform.LookAt(targetPostition);
            timer_DamageCoolDown += Time.deltaTime;
            timerSalto += Time.deltaTime;
            timer += Time.deltaTime;
            playerDistance = Vector3.Distance(player.position, transform.position);
            timerToNextAttack += Time.deltaTime;
            
            if(timerToNextAttack > timeToNextAttack)
            {
                hachaYterremotoAtaques[nextAttack] = true;
            }

            if (hachaYterremotoAtaques[0] && !playerInRange)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            else if (hachaYterremotoAtaques[0] && playerInRange)
            {
                ataqueHacha();
            }

            if(hachaYterremotoAtaques[1] && playerDistance <= 6)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
            }
            else if(hachaYterremotoAtaques[1] && playerDistance > 6)
            {
                ataqueTerremoto();
            }
            if(hachaYterremotoAtaques[1] && contraPared)
            {
                ataqueTerremoto();
            }
            
            if(!hachaYterremotoAtaques[0] && !hachaYterremotoAtaques[1])
            {
                if (contraPared)
                {
                    idleSpeed = -idleSpeed;
                }
                transform.position += transform.right * idleSpeed * Time.deltaTime;
            }

            if (timer > 0.5 && timer < 10)
            {
                for (int i = 0; i < materiales.Length; i++)
                {
                    materiales[i].color = ogMaterialColor;
                }
                timer = 10;
            }

            if (timerAtaque > attackTime)
            {
                anim.SetBool("atacar", false);
            }
            else if (timerAtaque > 1 && timerAtaque < 1.1 && playerInRange)
            {
                player.GetComponent<PlayerController>().recibirDanio(danio, gameObject);
            }

            if (timerSalto > saltoTiempo - 0.1 && timerSalto < saltoTiempo + 0.1)
            {
                player.GetComponentInChildren<CameraScript>().StartTerrmoto(terremotoTiempo);
                if(timer_DamageCoolDown > 2)
                {
                    player.GetComponent<PlayerController>().recibirDanio(danioTerremoto, gameObject);
                }
                anim.SetBool("terremoto", false);
            }

            if(hpActual <= 0)
            {
                puerta script = FindObjectOfType<puerta>();
                script.abrir();
                script.spawner.SetActive(true);
                Destroy(gameObject);
            }
        }
        else
        {
            anim.enabled = false;
        }
    }
    
    private void determineNextAttack()
    {
        timerToNextAttack = 0;
        timeToNextAttack = Random.Range(2f, 6f);
        hachaYterremotoAtaques[0] = false;
        hachaYterremotoAtaques[1] = false;

        if (hpActual > (hpMax / 3) * 2)
        {
            //phase 1
            nextAttack = 1;
        }
        else if (hpActual < (hpMax / 3) * 2 && hpActual > hpMax / 3)
        {
            //phase 2
            nextAttack = Random.Range(0, 2);
        }
        else
        {
            //phase 3
            nextAttack = 0;
        }
    }

    private void ataqueTerremoto()
    {
        anim.SetBool("terremoto", true);
        timerSalto = 0;
        determineNextAttack();
    }

    private void ataqueHacha()
    {
        anim.SetBool("atacar", true);
        timerAtaque = 0;
        determineNextAttack();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ATTACK" && timer_DamageCoolDown > damageCoolDownTime)
        {
            float danioJugador = col.GetComponent<AtaqueJugador>().danio;
            hpActual -= danioJugador;
            timer_DamageCoolDown = 0;
            Vector3 direction = (transform.position - col. transform.position).normalized;
            rb.AddForce(direction * knockbackForce);
            rb.AddRelativeForce(new Vector3(0, knockbackForceUP, 0));
            for (int i = 0; i < materiales.Length; i++)
            {
                materiales[i].color = colorDanio;
            }
            timer = 0;
        }

        if(col.tag == "PLAYER")
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "pared")
        {
            contraPared = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "pared")
        {
            contraPared = false;
        }
    }
}
