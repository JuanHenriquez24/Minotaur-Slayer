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
    public GameObject spawner;
    [SerializeField] private GameObject player;
    [SerializeField] private startEndLoseScreen sceneManager;
    public bool lost;

    void Start()
    {
        scriptLlaves = FindObjectOfType<KeyInventory>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<Collider>();
        minotauro.SetActive(false);
        spawner.SetActive(true);
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

            if (Input.GetKeyDown(KeyCode.X))
            {
                spawner.SetActive(false);
                player.transform.position = new Vector3(-116.8f, 3f, 34.29f);
                player.GetComponentInChildren<KeyInventory>().amountLLaves = 3;
                player.GetComponent<PlayerController>().HPActual = player.GetComponent<PlayerController>().HPmax;
            }

            if (lost)
            {
                sceneManager.winGame();
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
            spawner.SetActive(false);
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
