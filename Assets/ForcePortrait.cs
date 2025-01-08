using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePortrait : MonoBehaviour
{
    void Start()
    {
        // Force portrait orientation
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
