using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_HowToScan2 : MonoBehaviour
{
    public void GoBackToHowToScan1Scene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("HowToScan1_Scene");
    }

    public void GoToHowToScan3Scene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("HowToScan3_Scene");
    }
}
