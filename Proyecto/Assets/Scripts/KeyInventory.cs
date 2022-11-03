using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInventory : MonoBehaviour
{
    private bool en_rango_llave;
    private Collider current_col;
    private bool playing;
    public int amountLLaves;
 
    void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (playing)
        {
            if (Input.GetKeyDown(KeyCode.M) && en_rango_llave)
            {
                current_col.GetComponent<PickUpLlave>().pickedUp();
                amountLLaves++;
            }
        }
    }

    private void OnTriggerEnter (Collider col)
    {
        if (col.tag == "LLAVE")
        {
            en_rango_llave = true;
            current_col = col;
            col.GetComponent<PickUpLlave>().brillo.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "LLAVE")
        {
            en_rango_llave = false;
            col.GetComponent<PickUpLlave>().brillo.SetActive(false);
        }
    }

}
