using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeapondsInventory : MonoBehaviour
{
    [SerializeField] private Image[] array_UI_armas = new Image[3];
    private int[] currentWeaponSlots;

    public void cambiarArma()
    {
        for(int i = 0; i < currentWeaponSlots.Length; i++)
        {
            currentWeaponSlots[i] += 1;

            if (currentWeaponSlots[i] > 2)
            {
                currentWeaponSlots[i] -= 3;
            }
        }
    }
}
