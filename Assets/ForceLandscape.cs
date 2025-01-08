using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLandscape : MonoBehaviour
{
    void Start()
    {
        // Force landscape orientation
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
