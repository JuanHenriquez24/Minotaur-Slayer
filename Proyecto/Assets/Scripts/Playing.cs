using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : MonoBehaviour
{
    public bool playing;
    public bool pausa;

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
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && pausa)
        {
            sacarPausa();
            Cursor.visible = false;
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
