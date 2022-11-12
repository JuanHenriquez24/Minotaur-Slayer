using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sapo : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    [SerializeField] private float danio;
    [SerializeField] private float hpMax;
    private float hpActual;
    private float timer_DamageCoolDown;
    [SerializeField] private float damageCoolDownTime;
    [SerializeField] private GameObject hpPrefab;
    private Rigidbody rb;
    [SerializeField] private Material danioMaterial;
    private bool playing;
    private float timer;
    [SerializeField] private Material ogMaterial;
    private SkinnedMeshRenderer rndr;
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hpActual = hpMax;
        rb = GetComponent<Rigidbody>();
        rndr = GetComponentInChildren<SkinnedMeshRenderer>();
        parent = gameObject.transform.parent; 
        parent = gameObject.transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).tag == "PLAYER")
            {
                player = parent.GetChild(i);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        playing = GetComponentInParent<Playing>().playing;
        if (playing)
        {
            timer_DamageCoolDown += Time.deltaTime;
            timer += Time.deltaTime;
            if (timer > 0.5 && timer < 10)
            {
                Material[] mArray = rndr.materials;
                mArray[0] = ogMaterial;
                rndr.materials = mArray;

                rb.isKinematic = true;
                agent.enabled = true;
                timer = 10;
                if (hpActual <= 0)
                {
                    int cantHp = Random.Range(20, 30);
                    for (int i = 0; i < cantHp; i++)
                    {
                        Vector3 pos = new Vector3(Random.Range(-1f, 1.1f), 1, Random.Range(-1f, 1.1f));
                        GameObject hp = Instantiate(hpPrefab, transform.position + pos, transform.rotation);
                        hp.transform.parent = transform.parent;
                    }
                    Destroy(gameObject);
                }
            }
            else if (timer > 10)
            {
                agent.destination = player.position;
            }
        }
        else
        {
            agent.destination = transform.position;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "PLAYER")
        {
            player.GetComponent<PlayerController>().recibirDanio(danio, gameObject);
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "ATTACK" && timer_DamageCoolDown > damageCoolDownTime)
        {
            float danioJugador = col.GetComponent<AtaqueJugador>().danio;
            hpActual -= danioJugador;
            timer_DamageCoolDown = 0;
            agent.enabled = false;
            rb.isKinematic = false;
            rb.AddRelativeForce(new Vector3(0, 100, -100));
            Material[] mArray = rndr.materials;
            mArray[0] = danioMaterial;
            rndr.materials = mArray;
            timer = 0;
        }
    }
}
