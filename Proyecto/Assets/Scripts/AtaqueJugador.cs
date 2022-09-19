using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private bool playing;
    private Collider player_collider;
    private float attack_timer;
    private float attack_cool_down_timer;
    [SerializeField] private float coolDownTime;
    [SerializeField] private float attackTime;
    private bool attacking;
    public bool danioPlayer;

    void Start()
    {
        player_collider = gameObject.GetComponent<BoxCollider>();
        attack_cool_down_timer = coolDownTime;

    }

    void Update()
    {
        playing = gameObject.transform.parent.GetComponent<Playing>().playing;
        if (playing)
        {
            if (attacking)
            {
                attack_timer += Time.deltaTime;
            }
            else
            {
                attack_cool_down_timer += Time.deltaTime;
            }

            if (attack_timer > attackTime)
            {
                attacking = false;
                attack_timer = 0;
            }

            if (Input.GetKeyDown(KeyCode.M) && attack_cool_down_timer > coolDownTime && !attacking)
            {

                player_collider.enabled = true;
                attacking = true;
                attack_cool_down_timer = 0;

            }
        }
    }
}
    
