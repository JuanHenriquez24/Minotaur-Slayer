using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playing : MonoBehaviour
{
    public bool playing;
    public bool pausa;
    private GameObject screen_pausa;
    private GameObject overlay;

    void Start()
    {
        screen_pausa = GameObject.Find("PAUSA_SCREEN");
        overlay = GameObject.Find("OVERLAY");
        Cursor.visible = false;
        playing = true;
        screen_pausa.SetActive(false);
        overlay.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !pausa)
        {
            ponerPausa();
        }
        else if(Input.GetKeyDown(KeyCode.P) && pausa)
        {
            sacarPausa();
        }
    }

    public void ponerPausa()
    {
        playing = false;
        pausa = true;
        screen_pausa.SetActive(true);
        Cursor.visible = true;
        overlay.SetActive(false);
    }

    public void sacarPausa()
    {
        playing = true;
        pausa = false;
        screen_pausa.SetActive(false);
        Cursor.visible = false;
        overlay.SetActive(true);
    }
}
