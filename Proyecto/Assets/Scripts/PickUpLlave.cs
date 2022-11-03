using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpLlave: MonoBehaviour
{
    [SerializeField] GameObject object_UI;
    [SerializeField] Color32 color;
    public GameObject brillo;

    void Start()
    {
        brillo.SetActive(false);
    }

    public void pickedUp()
    {
        object_UI.GetComponent<Image>().color = color;
        gameObject.SetActive(false);
    }
}