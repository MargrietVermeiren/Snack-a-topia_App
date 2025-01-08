using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_HowToScan1 : MonoBehaviour
{
    public void GoBackToKidsStartScene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("KidsStart_Scene");
    }

    public void GoToHowToScan2Scene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("HowToScan2_Scene");
    }
}
