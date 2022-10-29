using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpCollision : MonoBehaviour
{
    public bool enRangoArma;
    public GameObject armaEnRango;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "WEAPON")
        {
            enRangoArma = true;
            armaEnRango = col.gameObject;
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
