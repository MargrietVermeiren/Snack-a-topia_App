using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_Scanning : MonoBehaviour
{
    public void GoBackToKidsStartScene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("KidsStart_Scene");
    }
}
