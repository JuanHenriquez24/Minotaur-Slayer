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
            if (Input.GetKeyDown(KeyCode.F))
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
    }

    IEnumerator cambiarArma()
    {
        anim.SetBool(array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().changeBool, true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool(array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().changeBool, false);
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
        UIarrayArmas[0].sprite = array_armas[currentWeaponSlot].GetComponent<PlayerWeaponScript>().inventoryImage;
        int r = currentWeaponSlot;
        r++;
        for(int i = 1; i < array_armas.Length; i++)
        {
            if(r == array_armas.Length)
            {
                r = 0;
                UIarrayArmas[i].sprite = array_armas[r].GetComponent<PlayerWeaponScript>().inventoryImage;
                r++;
            }
            else if((r > currentWeaponSlot || r < currentWeaponSlot) && array_armas[r])
            {
                UIarrayArmas[i].sprite = array_armas[r].GetComponent<PlayerWeaponScript>().inventoryImage;
                r++;
            }
        }
    }
}
