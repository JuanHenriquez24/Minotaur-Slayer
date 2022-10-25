using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotauro : MonoBehaviour
{
    // 1 = terremotear, 2 = atacar
    private int phase;

    
    [SerializeField] private float hpMax;
    private float hpActual;
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
    private bool playerInRange;
    private float timerAtaque;
    private float attackTime;
    [SerializeField] private float terremotoTiempo;
    private float saltoTiempo;
    private float timerSalto;

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
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            anim.enabled = true;
            timerAtaque += Time.deltaTime;
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;
            timer_DamageCoolDown += Time.deltaTime;
            timerSalto += Time.deltaTime;

            timer += Time.deltaTime;
            if (timer > 0.5 && timer < 10)
            {
                for (int i = 0; i < materiales.Length; i++)
                {
                    materiales[i].color = ogMaterialColor;
                }
                timer = 10;
                if (hpActual <= 0)
                {
                    Destroy(gameObject);
                }
            }

            if (timerAtaque > attackTime)
            {
                anim.SetBool("atacar", false);
            }
            else if (timerAtaque > 1 && timerAtaque < 1.1 && playerInRange)
            {
                player.GetComponent<PlayerController>().recibirDanio(danio, gameObject);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                ataqueHacha();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                ataqueTerremoto();
            }

            if (timerSalto > saltoTiempo - 0.1 && timerSalto < saltoTiempo + 0.1)
            {
                player.GetComponentInChildren<CameraScript>().StartTerrmoto(terremotoTiempo);
                anim.SetBool("terremoto", false);
            }
        }
        else
        {
            anim.enabled = false;
        }
    }

    private void ataqueTerremoto()
    {
        anim.SetBool("terremoto", true);
        timerSalto = 0;
    }

    private void ataqueHacha()
    {
        anim.SetBool("atacar", true);
        timerAtaque = 0;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ATTACK" && timer_DamageCoolDown > damageCoolDownTime)
        {
            float danioJugador = col.GetComponent<AtaqueJugador>().danio;
            hpActual -= danioJugador;
            timer_DamageCoolDown = 0;
            Vector3 direction = (transform.position - col. transform.position).normalized;
            Debug.Log(direction);
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
}
