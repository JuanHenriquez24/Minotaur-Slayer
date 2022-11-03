using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilo : MonoBehaviour
{
    private TrailRenderer rndr;

    void Start()
    {
        rndr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rndr.emitting = !rndr.emitting;
        }
    }
}
