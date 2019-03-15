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

    private int cur = 0;
    private string[] order = new string[] { "Profile", "Friends", "Map", "Settings" };
    public Transform options;
    public Transform extensions;

    private void ButtonMode(Transform button, bool mode)
    {
        if (mode)
        {
            button.GetComponent<Image>().color = new Color32(255, 181, 0, 255);
        }
        else
        {
            button.GetComponent<Image>().color = new Color32(255, 255, 225, 121);
        }

    }

    bool inTranslation = false;
    public IEnumerator Toggle(int dir) // scrolls through the menu options
    {
        float transitionTime = 0.6f;
        float transitionConstant = 0.09f;

        if (!inTranslation && cur + dir >= 0 && cur + dir < order.Length) // only toggle if we're not already toggling and if we have room
        {
            inTranslation = true;

            // get the variables
            string oldName = order[cur];
            cur += dir;
            string newName = order[cur];
            float startPos = options.position.y;
            float translation = dir * transitionConstant;
            float startingoffset = options.parent.position.y;

            extensions.Find(oldName).gameObject.SetActive(false); // remove old menu
            ButtonMode(options.Find(oldName), false); // unmark button

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

            // show new menu
            ButtonMode(options.Find(newName), true);
            extensions.Find(newName).gameObject.SetActive(true);

            // allow translation again
            inTranslation = false;
        }
        yield return null;

    }
    // Update is called once per frame
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
