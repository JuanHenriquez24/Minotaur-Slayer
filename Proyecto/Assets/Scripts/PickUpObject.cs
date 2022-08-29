using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    private GameObject texto;
    private bool en_rango_obj;
    private bool playing;

    void Start()
    {
        texto = GameObject.Find("TXT_PICK_UP");
        texto.gameObject.SetActive(false);
        en_rango_obj = false;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        texto.transform.rotation = Camera.main.transform.rotation;

        if (playing)
        {
            if (en_rango_obj)
            {
                texto.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.M))
                {
                    texto.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            texto.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PLAYER")
        {
            en_rango_obj = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "PLAYER")
        {
            en_rango_obj = false;
            texto.gameObject.SetActive(false);
        }
    }
}
