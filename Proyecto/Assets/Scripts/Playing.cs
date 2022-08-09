using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : MonoBehaviour
{
    public bool playing;

    void Start()
    {
        Cursor.visible = false;
        playing = true;
    }
}
