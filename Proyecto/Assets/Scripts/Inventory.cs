using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool pickeado;
    public GameObject PICKUP_OBJECT;
    public GameObject Llave1;
    public GameObject Llave2;
    public GameObject Llave3;

    // Start is called before the first frame update
    void Start()
    {
        pickeado = false;
    }

    // Update is called once per frame
    void Update()
    {
    if (PICKUP_OBJECT == true)
        {
            pickeado = false;
            Llave1.SetActive(false);
        }
        if (PICKUP_OBJECT == false)
        {
            pickeado = true;
            Llave1.SetActive(true);
        }
     /*
        if (tienellave == true)
        {
            llave1.setactive(true);
        }
        if (tienellave == false)
        {
            llave1.setactive(false);
        }
        */
    }
}
