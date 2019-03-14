using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiritoMovement : MonoBehaviour
{
    private Animator kiritoController;
    // Start is called before the first frame update
    void Start()
    {
        kiritoController = GetComponent<Animator>();
        kiritoController.SetFloat("Vx", 0);
        kiritoController.SetFloat("Vy", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
