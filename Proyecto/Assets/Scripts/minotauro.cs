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

    void Start()
    {
        anim = GetComponent<Animator>();
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
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            transform.LookAt(player);
            transform.position += transform.forward * 5 * Time.deltaTime;
            timer_DamageCoolDown += Time.deltaTime;

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
        }
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
    }
}
