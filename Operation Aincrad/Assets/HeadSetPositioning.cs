using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HeadSetPositioning : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        InputTracking.disablePositionalTracking = true;
        this.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
