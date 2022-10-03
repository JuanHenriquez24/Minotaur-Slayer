using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private Collider playerCollider;
    [SerializeField] private float coolDownTime;
    private float coolDownActual;
    private float timer_Cool_Down;
    public float attackTime;
    private float timer_Attack;
    public float danio;
    private bool playing;
    private AnimationClip clipAtaque;
    private AnimationClip clipIdle;
    private bool attacking;
    [SerializeField] private GameObject currentWeapond;
    private Animator anim;
    [SerializeField] private GameObject brazos;
    private string animBool;
    private string idleBool;

    void Start()
    {
        timer_Cool_Down = 1000;
        playerCollider = GetComponent<Collider>();
        playerCollider.enabled = false;
        anim = brazos.GetComponent<Animator>();
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (playing)
        {
            attackTime = currentWeapond.GetComponent<PlayerWeaponScript>().attackLength;
            clipAtaque = currentWeapond.GetComponent<PlayerWeaponScript>().animClip;
            danio = currentWeapond.GetComponent<PlayerWeaponScript>().damage;
            clipIdle = currentWeapond.GetComponent<PlayerWeaponScript>().idleClip;
            coolDownActual = coolDownTime + attackTime;
            animBool = currentWeapond.GetComponent<PlayerWeaponScript>().boolName;
            timer_Cool_Down += Time.deltaTime;
            idleBool = currentWeapond.GetComponent<PlayerWeaponScript>().idleBool;

            if (Input.GetKeyDown(KeyCode.M) && timer_Cool_Down > coolDownActual)
            {
                attacking = true;
                anim.SetBool(animBool, true);
                playerCollider.enabled = true;
                timer_Cool_Down = 0;
            }
            if (timer_Cool_Down > attackTime)
            {
                attacking = false;
                playerCollider.enabled = false;

                anim.SetBool(animBool, false);
            }
            if (!attacking)
            {
                anim.SetBool(idleBool, true);
            }
            else
            {

                anim.SetBool(idleBool, false);
            }
        }
    }
}
