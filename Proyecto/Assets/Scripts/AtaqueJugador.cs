using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private bool playing;
    [SerializeField] private Collider player_collider;
    private float attack_cool_down_timer;
    [SerializeField] private float coolDownTime;
    public int danio;

    void Start()
    {
        player_collider = gameObject.GetComponent<BoxCollider>();
        attack_cool_down_timer = coolDownTime;
        player_collider.enabled = false;

    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (playing)
        {
            attack_cool_down_timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.M) && attack_cool_down_timer > coolDownTime)
            {

                player_collider.enabled = true;
                attack_cool_down_timer = 0;

            }
        }
    }
}
    
