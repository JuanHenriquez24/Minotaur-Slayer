using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject arma;
    

    public void pickedUp()
    {
        gameObject.SetActive(false);
    }
}
