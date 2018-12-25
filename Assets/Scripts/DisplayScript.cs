﻿using UnityEngine;
using System.Collections;

public class DisplayScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
        if (Display.displays.Length > 3)
            Display.displays[3].Activate();
        if (Display.displays.Length > 4)
            Display.displays[4].Activate();
        if (Display.displays.Length > 5)
            Display.displays[5].Activate();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
