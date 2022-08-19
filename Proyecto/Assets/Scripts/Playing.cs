using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : MonoBehaviour
{
    public bool playing;
    private bool pausa;

    void Start()
    {
        Cursor.visible = false;
        playing = true;
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

    private void ponerPausa()
    {
        playing = false;
        pausa = true;
    }

    private void sacarPausa()
    {
        playing = true;
        pausa = false;
    }
}
