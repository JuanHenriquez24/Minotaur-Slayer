using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    private int timeTo;
    private bool playing;
    private float timer;
    private int i;

    void Start()
    {
        playing = GetComponentInParent<Playing>().playing;
        spawnRandomInRandom();
    }
    
    void Update()
    {
        playing = GetComponentInParent<Playing>().playing;
        if (playing)
        {
            timer += Time.deltaTime;

            if(timer > timeTo)
            {
                spawnRandomInRandom();
                timer = 0;
            }
        }
    }

    void spawnRandomInRandom()
    {
        i = Random.Range(0, prefabs.Length);
        GameObject enemigo = Instantiate(prefabs[i], new Vector3(Random.Range(-140f, -74f), 1, Random.Range(-30f, 33f)), transform.rotation);
        enemigo.transform.parent = gameObject.transform.parent;
        timeTo = Random.Range(5, 15);
    }
}
