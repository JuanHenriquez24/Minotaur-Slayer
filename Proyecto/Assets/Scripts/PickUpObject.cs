using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    private GameObject texto;
    private bool en_rango_obj;
    private bool playing;
    private bool pausa;

    void Start()
    {
        texto = GameObject.Find("TXT_PICK_UP");
        texto.gameObject.SetActive(false);
        en_rango_obj = false;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        pausa = gameObject.GetComponentInParent<Playing>().pausa;

        if (playing)
        {
            if (Input.GetKey(KeyCode.M) && en_rango_obj)
            {
                texto.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (pausa)
            {
                texto.gameObject.SetActive(false);
            }
            else if (en_rango_obj)
            {
                texto.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PLAYER")
        {
            texto.gameObject.SetActive(true);
            en_rango_obj = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "PLAYER")
        {
            texto.gameObject.SetActive(false);
            en_rango_obj = false;
        }
    }
}
