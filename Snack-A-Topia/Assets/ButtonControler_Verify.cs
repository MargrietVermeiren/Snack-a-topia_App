using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_Verify : MonoBehaviour
{
    public void GoBackToStartScene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("Start_Scene");
    }
}
