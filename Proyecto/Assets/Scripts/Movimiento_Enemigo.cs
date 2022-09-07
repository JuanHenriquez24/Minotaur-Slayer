using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Enemigo : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private bool playing;
    private Transform parent;
    private Vector3 look_position;

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
            look_position = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(look_position);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
