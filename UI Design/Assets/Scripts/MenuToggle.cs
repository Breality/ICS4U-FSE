using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }



    private void ButtonMode(Transform button, bool mode)
    {
        if (mode)
        {
            button.GetComponent<Image>().color = new Color32(255, 181, 0, 255);
            extensions.Find(button.name).gameObject.SetActive(true);
        }
        else
        {
            button.GetComponent<Image>().color = new Color32(255, 255, 225, 121);
            extensions.Find(button.name).gameObject.SetActive(false);
        }
    }

    bool inTranslation = false;
    bool isOpen = false;
    private int cur = 0;
    public Transform options;
    public Transform extensions;
    private string[] order = new string[] { "Start", "Profile", "Friends", "Map", "Settings" };
    float transitionConstant = 0.09f;

    public IEnumerator Toggle(int dir) // scrolls through the menu options
    {
        float transitionTime = 0.5f * Mathf.Abs(dir);

        if (!inTranslation && cur + dir > 0 && cur + dir < order.Length) // only toggle if we're not already toggling and if we have room
        {
            inTranslation = true;

            // get the variables
            string oldName = order[cur];
            cur += dir;
            string newName = order[cur];
            float startPos = options.position.y;
            float translation = dir * transitionConstant;
            float startingoffset = options.parent.position.y;

            ButtonMode(options.Find(oldName), false); // unmark button and remove old menu

            // translate buttons
            float startTime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < startTime + transitionTime)
            {
                // this changes the object's position in world space, should be based on camera
                options.position = new Vector3(options.position.x,
                    startPos + translation * (Time.realtimeSinceStartup - startTime) / transitionTime + (options.parent.position.y - startingoffset),
                    options.position.z);
                yield return new WaitForSeconds(0.001f);
            }
            options.position = new Vector3(options.position.x, startPos + translation + (options.parent.position.y - startingoffset), options.position.z);

            ButtonMode(options.Find(newName), true); // show new menu
            inTranslation = false; // allow translation again
        }
        yield return null;

    }
    // Update is called once per frame
    public void Activate(bool value)
    {
        print(value);
        if (value && cur > 0) // reset the values
        {
            ButtonMode(options.Find(order[cur]), false);
            options.Translate(new Vector3(0, transitionConstant * cur *-1, 0));
            cur = 0;
        }
        options.parent.gameObject.SetActive(value);
        isOpen = value;
    }

    float lastswitch = 0;
    public void switchSeen() // for testing
    {
        if (Time.realtimeSinceStartup - lastswitch > 1)
        {
            Activate(!isOpen);
            lastswitch = Time.realtimeSinceStartup;
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.K)) // up
        {
            StartCoroutine(Toggle(-1));
        }
        if (Input.GetKey(KeyCode.M)) // down
        {
            StartCoroutine(Toggle(1));
        }
    }
}
