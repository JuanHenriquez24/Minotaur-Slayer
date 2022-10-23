using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeapondsInventory : MonoBehaviour
{
    [SerializeField] private GameObject[] array_armas;
    [SerializeField] private Image[] UIarrayArmas;
    private int currentWeaponSlot = 0;
    private int availableWeapons;
    [SerializeField] private GameObject espada;
    private AtaqueJugador scritpAtaque;

    private void Start()
    {
        array_armas[0] = espada;
        scritpAtaque = GetComponent<AtaqueJugador>();
        availableWeapons = array_armas.Length;
        for(int i = 0; i < availableWeapons; i++)
        {
            array_armas[i].SetActive(false);
        }
        array_armas[currentWeaponSlot].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cambiarArma();
        }
    }

    private void AgregarArma(GameObject nuevaArma)
    {
        array_armas[availableWeapons] = nuevaArma;
        availableWeapons = array_armas.Length;
    }

    private void cambiarArma()
    {
        array_armas[currentWeaponSlot].SetActive(false);
        currentWeaponSlot++;
        if (currentWeaponSlot == availableWeapons)
        {
            currentWeaponSlot = 0;
        }
        array_armas[currentWeaponSlot].SetActive(true);
        scritpAtaque.currentWeapond = array_armas[currentWeaponSlot];
    }

    private void updateInventory()
    {

    }
}
