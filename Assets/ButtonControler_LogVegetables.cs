using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_LogVegetables : MonoBehaviour
{
    public void NavigateBackToGoalLogScene()
    {
        // Navigate back to Goal-Log_Scene
        SceneManager.LoadScene("Goal-Log_Scene");
    }
}
