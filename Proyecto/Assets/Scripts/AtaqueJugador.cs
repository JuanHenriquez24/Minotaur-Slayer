using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private Collider playerCollider;
    [SerializeField] private float coolDownTime;
    private float timer_Cool_Down;
    private float attackTime;
    private float timer_Attack;
    public float danio;
    private bool playing;
    [SerializeField] private GameObject brazos;
    private Animator anim;
    private AnimationClip clipAtaque;
    private bool attacking;

    void Start()
    {
        anim = brazos.GetComponent<Animator>();
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "AtaqueEspada")
            {
                clipAtaque = clip;
                attackTime = clipAtaque.length;
            }
        }
        coolDownTime += attackTime;
        timer_Cool_Down = coolDownTime;
        playerCollider = GetComponent<Collider>();
        playerCollider.enabled = false;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (playing)
        {
            timer_Cool_Down += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.M) && timer_Cool_Down > coolDownTime)
            {
                attacking = true;
                anim.SetBool("Attacking", true);
                playerCollider.enabled = true;
                timer_Cool_Down = 0;
            }
            if (timer_Cool_Down > attackTime)
            {
                attacking = true;
                playerCollider.enabled = false;

                anim.SetBool("Attacking", false);
            }
        }
    }
}
