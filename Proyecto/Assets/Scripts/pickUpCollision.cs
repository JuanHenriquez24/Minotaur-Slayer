using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpCollision : MonoBehaviour
{
    public bool enRangoArma;
    public GameObject armaEnRango;
    private float hp;

    private void Update()
    {
        hp = GetComponent<PlayerController>().HPActual;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "WEAPON")
        {
            enRangoArma = true;
            armaEnRango = col.gameObject;
        }
        else if(col.tag == "hp" && hp < 100)
        {
            hp++;
            GetComponent<PlayerController>().HPActual = hp;
            Destroy(col);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "WEAPON")
        {
            enRangoArma = false;
        }
    }
}
