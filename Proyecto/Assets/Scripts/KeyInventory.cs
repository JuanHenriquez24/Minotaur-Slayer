using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInventory : MonoBehaviour
{
    private bool en_rango_llave;
    private Collider current_col;
    private bool playing;

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (playing)
        {
            if (Input.GetKeyDown(KeyCode.M) && en_rango_llave)
            {
                current_col.GetComponent<PickUpLlave>().pickedUp();
            }
        }
    }

    private void OnTriggerEnter (Collider col)
    {
        if (col.tag == "LLAVE")
        {
            en_rango_llave = true;
            current_col = col;
            
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "LLAVE")
        {
            en_rango_llave = false;
        }
    }

}
