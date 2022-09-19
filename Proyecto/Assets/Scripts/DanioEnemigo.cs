using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{
    [SerializeField] private int vidaMax;
    public int vidaActual;
    public int danio;
    private float damage_cool_down;

    void Start()
    {
        damage_cool_down = 5;
        vidaActual = vidaMax;
    }

    void Update()
    {
        if(vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "ATTACK")
        {
            Debug.Log("GGGGGG");
            recibirDanio(col.GetComponent<AtaqueJugador>().danio);
            damage_cool_down = 0;
        }
    }

    public void recibirDanio(int danio)
    {
        vidaActual -= danio;
    }
}
