using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{

    public PlayerController PC;
    [SerializeField] Image HPBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PC = FindObjectOfType<PlayerController>();
        HPBar.fillAmount = PC.HPActual / PC.HPmax; 
    }
}
