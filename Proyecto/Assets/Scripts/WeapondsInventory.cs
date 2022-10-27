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
    [SerializeField] private Color ogColor;
    private bool enRangoArma;
    private GameObject armaEnRango;
    private bool playing;

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
        updateInventory();
    }

    private void Update()
    {
        playing = gameObject.GetComponentInParent<Playing>().playing;
        if (playing)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                cambiarArma();
            }

            if(Input.GetKeyDown(KeyCode.M) && enRangoArma)
            {
                Debug.Log("picking");
                AgregarArma(armaEnRango.GetComponent<PickUpWeapon>().arma);
                armaEnRango.GetComponent<PickUpWeapon>().pickedUp();
            }
        }
    }

    private void AgregarArma(GameObject nuevaArma)
    {
        array_armas[availableWeapons] = nuevaArma;
        UIarrayArmas[availableWeapons].color = nuevaArma.GetComponent<PlayerWeaponScript>().inventoryColor;
        availableWeapons = array_armas.Length;
    }

    private void cambiarArma()
    {
        array_armas[currentWeaponSlot].SetActive(false);
        currentWeaponSlot++;
        if (currentWeaponSlot >= array_armas.Length)
        {
            currentWeaponSlot = 0;
        }
        array_armas[currentWeaponSlot].SetActive(true);
        scritpAtaque.currentWeapond = array_armas[currentWeaponSlot];
        updateInventory();
    }

    private void updateInventory()
    {
        UIarrayArmas[0].color = array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().inventoryColor;
        int r = currentWeaponSlot;
        r++;
        for(int i = 1; i < array_armas.Length; i++)
        {
            if(r == array_armas.Length)
            {
                r = 0;
                UIarrayArmas[i].color = array_armas[r].GetComponent<PlayerWeaponScript>().inventoryColor;
                r++;
            }
            else if(r > currentWeaponSlot || r < currentWeaponSlot)
            {
                UIarrayArmas[i].color = array_armas[r].GetComponent<PlayerWeaponScript>().inventoryColor;
                r++;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("colliding");
        if (col.name == "LanzaPickUP")
        {
            Debug.Log("En rango");
            enRangoArma = true;
            armaEnRango = col.gameObject;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "w")
        {
            Debug.Log("Fuera de rango");
            enRangoArma = false;
        }
    }
}
