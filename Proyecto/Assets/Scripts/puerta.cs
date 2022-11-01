using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    private bool enRango;
    private KeyInventory scriptLlaves;
    private int amountLlaves;
    private Animator anim;

    void Start()
    {
        scriptLlaves = FindObjectOfType<KeyInventory>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        amountLlaves = scriptLlaves.amountLLaves;
        if(enRango && Input.GetKeyDown(KeyCode.M))
        {
            if(amountLlaves < 3)
            {
                anim.SetBool("trying", true);
            }
            else
            {

            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PLAYER_PICK")
        {
            enRango = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "PLAYER_PICK")
        {
            enRango = false;
        }
    }
}
