using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int cur = 0;
    private string[] order = new string[] { "Profile", "Friends", "Map", "Settings" };

    public void Toggle(int dir) // up and down (1 and -1)
    {
        cur += dir;
        string newName = order[cur];
        foreach (Transform child in transform)
        {
            RectTransform myRectTransform = GetComponent<RectTransform>();
            myRectTransform.localPosition += Vector3.right;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
