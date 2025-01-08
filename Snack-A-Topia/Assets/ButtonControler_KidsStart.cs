using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_KidsStart : MonoBehaviour
{
    public void GoBackToStartScene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("Start_Scene");
    }

    public void GoToGame()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("Game_Scene");
    }

    public void GoToHowToScan1Scene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("HowToScan1_Scene");
    }
}
