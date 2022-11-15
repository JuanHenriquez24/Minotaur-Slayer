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
    private pickUpCollision script;
    private Animator anim;
    [SerializeField] GameObject brazos;

    private void Start()
    {
        anim = brazos.GetComponent<Animator>();
        script = GetComponentInParent<pickUpCollision>();
        array_armas[0] = espada;
        scritpAtaque = GetComponent<AtaqueJugador>();
        availableWeapons = 1;
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
            enRangoArma = script.enRangoArma;
            armaEnRango = script.armaEnRango;
            if (Input.GetKeyDown(KeyCode.F) && availableWeapons > 1)
            {
                StartCoroutine(cambiarArma());
            }

            if(Input.GetKeyDown(KeyCode.M) && enRangoArma)
            {
                AgregarArma(armaEnRango.GetComponent<PickUpWeapon>().arma);
                armaEnRango.GetComponent<PickUpWeapon>().pickedUp();
            }
        }
    }

    private void AgregarArma(GameObject nuevaArma)
    {
        array_armas[availableWeapons] = nuevaArma;
        UIarrayArmas[availableWeapons].sprite = nuevaArma.GetComponent<PlayerWeaponScript>().inventoryImage;
        availableWeapons++;
        script.enRangoArma = false;
        updateInventory();
    }

    IEnumerator cambiarArma()
    {
        anim.SetBool(array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().changeBool, true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool(array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().changeBool, false);
        array_armas[currentWeaponSlot].SetActive(false);
        currentWeaponSlot++;
        if (currentWeaponSlot >= availableWeapons)
        {
            currentWeaponSlot = 0;
        }
        array_armas[currentWeaponSlot].SetActive(true);
        scritpAtaque.currentWeapond = array_armas[currentWeaponSlot];
        updateInventory();
    }

    private void updateInventory()
    {
        UIarrayArmas[0].sprite = array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().inventoryImage;
        if(availableWeapons > 1)
        {
            if(currentWeaponSlot == availableWeapons - 1)
            {
                UIarrayArmas[1].enabled = true;
                UIarrayArmas[1].sprite = array_armas[0].GetComponent<PlayerWeaponScript>().inventoryImage;
            }
            else
            {
                UIarrayArmas[1].enabled = true;
                UIarrayArmas[1].sprite = array_armas[currentWeaponSlot + 1].GetComponent<PlayerWeaponScript>().inventoryImage;
            }
        }
        else
        {
            UIarrayArmas[1].enabled = false;
        }
    }
}
