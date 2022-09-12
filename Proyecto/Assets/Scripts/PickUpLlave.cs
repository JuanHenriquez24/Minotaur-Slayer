using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpLlave: MonoBehaviour
{
    public bool en_rango_obj;
    [SerializeField] GameObject object_UI;
    [SerializeField] Color32 color;

    void Start()
    {
        en_rango_obj = false;
    }

    public void pickedUp()
    {
        object_UI.GetComponent<Image>().color = color;
        gameObject.SetActive(false);
    }
}
