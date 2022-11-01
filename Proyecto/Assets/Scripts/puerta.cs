using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    private bool enRango;
    private KeyInventory scriptLlaves;
    private int amountLlaves;
    private Animator anim;
    private bool playing;
    private Collider boxCollider;
    private bool battling;
    [SerializeField] private GameObject minotauro;

    void Start()
    {
        scriptLlaves = FindObjectOfType<KeyInventory>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<Collider>();
        minotauro.SetActive(false);
    }

    void Update()
    {
        playing = GetComponentInParent<Playing>().playing;
        if (playing)
        {
            anim.SetBool("trying", false);
            amountLlaves = scriptLlaves.amountLLaves;
            if (enRango && Input.GetKeyDown(KeyCode.M))
            {
                if (amountLlaves < 3)
                {
                    anim.SetBool("trying", true);
                }
                else
                {
                    abrir();
                }
            }
        }
    }

    public void abrir()
    {
        anim.SetBool("open", true);
        boxCollider.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PLAYER_PICK")
        {
            enRango = true;
        }
        if(col.tag == "PLAYER" && minotauro)
        {
            anim.SetBool("open", false);
            boxCollider.enabled = true;
            minotauro.SetActive(true);
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
