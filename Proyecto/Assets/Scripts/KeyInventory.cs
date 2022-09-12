using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInventory : MonoBehaviour
{
    private bool en_rango;
    private Collider current_col;
    private bool playing;

    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (Input.GetKeyDown(KeyCode.M) && en_rango && playing)
        {
            current_col.GetComponent<PickUpLlave>().pickedUp();
        }
    }

    private void OnTriggerEnter (Collider col)
    {
        if (col.tag == "LLAVE")
        {
            col.GetComponent<PickUpLlave>().en_rango_obj = true;
            en_rango = true;
            current_col = col;
            
        }
    }
    private void OnTriggerExit(Collider col)
    {
        col.GetComponent<PickUpLlave>().en_rango_obj = false;
        en_rango = false;
    }

}
