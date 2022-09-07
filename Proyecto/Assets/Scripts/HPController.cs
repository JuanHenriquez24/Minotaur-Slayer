using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{

    public PlayerController PC;
    [SerializeField] Image HPBar;
    public GameObject BarraDeVida;
    
    void Update()
    {
        PC = FindObjectOfType<PlayerController>();
        HPBar.fillAmount = PC.HPActual / PC.HPmax; 
        //if (muerte == true)
        {
            // para gameobjects
            //BarraDeVida.SetActive(false);
            // para textos BarraDeVida.enabled = false;
        }
    }
}
