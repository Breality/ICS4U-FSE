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
        XRDevice.DisableAutoXRCameraTracking(cam, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
