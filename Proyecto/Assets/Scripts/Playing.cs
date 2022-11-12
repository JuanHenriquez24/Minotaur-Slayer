using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playing : MonoBehaviour
{
    public bool playing;
    public bool pausa;
    [SerializeField] private GameObject screen_pausa;
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject intro;
    private bool inIntro;

    void Start()
    {
        ponerPausa();
        screen_pausa.SetActive(false);
        intro.SetActive(true);
        inIntro = true;
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

        if (inIntro && Input.GetKeyDown(KeyCode.M))
        {
            inIntro = false;
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
        intro.SetActive(false);
    }
}
