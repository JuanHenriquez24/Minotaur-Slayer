using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeapondsInventory : MonoBehaviour
{
    [SerializeField] private Image[] weapon_slots;
    [SerializeField] private GameObject[] weapons;
    GameObject current_weapon;

    void Start()
    {
        current_weapon = weapons[0];
    }

    void Update()
    {
        weapon_slots[0].color = current_weapon.GetComponent<PickUpArma>().color;
    }
}
