﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    private bool en_rango_obj;
    private bool playing;

    void Start()
    {
        en_rango_obj = false;
    }

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;

        if (playing)
        {
            if (en_rango_obj)
            {
                if (Input.GetKey(KeyCode.M))
                {
                    gameObject.SetActive(false);
                }
            }
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
        }
    }
}
