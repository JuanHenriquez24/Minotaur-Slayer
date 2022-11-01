using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinotaurHP : MonoBehaviour
{

    public minotauro PC;
    [SerializeField] Image HPBar;
    public GameObject BarraDeVida;

    void Update()
    {
        PC = FindObjectOfType<minotauro>();
        HPBar.fillAmount = PC.hpActual / PC.hpMax;
    }
}