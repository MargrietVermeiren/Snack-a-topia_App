using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_HowToScan3 : MonoBehaviour
{
    public void GoBackToHowToScan2Scene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("HowToScan2_Scene");
    }

    public void GoToScanningScene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("Scanning_Scene");
    }
}
