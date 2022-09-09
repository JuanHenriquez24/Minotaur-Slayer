using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool pickeado;
    public GameObject PICKUP_OBJECT;
    public GameObject Llave1UI;
    public GameObject Llave1;
    private bool pickeado1;
    public GameObject Llave2;
    public GameObject Llave3;

    // Start is called before the first frame update
    void Start()
    {
        Llave1UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pickeado1 = Llave1.GetComponent<PickUpObject>().pickeado;
        if (pickeado == true)
        {
            Llave1UI.SetActive(true);
        }
        else
        {
            Llave1UI.SetActive(false);
        }
    /*if (PICKUP_OBJECT == true)
        {
            Llave1.SetActive(false);
        }
        if (PICKUP_OBJECT == false)
        {
            Llave1.SetActive(true);
        }

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
