using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private bool en_rango_enemigo;
    private bool playing;
    private Collider player_collider;

    void Start()
    {
        player_collider = gameObject.GetComponent<BoxCollider>();
    }
    
    void Update()
    {
        playing = gameObject.transform.parent.GetComponent<Playing>().playing;
        if (playing)
        {
            if(en_rango_enemigo && Input.GetKeyDown(KeyCode.M))
            {

            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PAIN")
        {
            en_rango_enemigo = true;
        }
    }
    
    private void OnTriggerExit (Collider col)
    {
        if(col.tag == "PAIN")
        {
            en_rango_enemigo = false;
        }
    }
}
