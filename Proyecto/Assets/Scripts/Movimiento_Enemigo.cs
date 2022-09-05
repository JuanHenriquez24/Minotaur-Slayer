using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Enemigo : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private bool playing;
    private Transform parent;
    public Vector3 test;

    void Start()
    {
        parent = gameObject.transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            if(parent.GetChild(i).tag == "PLAYER")
            {
                player = parent.GetChild(i);
                break;
            }
        }
    }
    
    void Update()
    {
        playing = parent.GetComponent<Playing>().playing;

        if (playing)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
