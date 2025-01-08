using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_GoalLog : MonoBehaviour
{
    public void NavigateToGoalScene()
    {
        // Navigate to HowToSetGoal1_Scene
        SceneManager.LoadScene("HowToSetGoal1_Scene");
    }

    public void NavigateToLogScene()
    {
        // Navigate to LogVegetables_Scene
        SceneManager.LoadScene("LogVegetables_Scene");
    }

    public void NavigateBackToStartScene()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("Start_Scene");
    }
}
