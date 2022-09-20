using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private Collider playerCollider;
    [SerializeField] private float coolDownTime;
    private float timer_Cool_Down;
    [SerializeField] private float attackTime;
    private float timer_Attack;
    public float danio;
    private bool playing;

    void Start()
    {
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
                playerCollider.enabled = true;
                timer_Cool_Down = 0;
            }
            if (timer_Cool_Down > attackTime)
            {
                playerCollider.enabled = false;
            }
        }
    }
}
