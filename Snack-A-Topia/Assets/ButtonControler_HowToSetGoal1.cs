using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController_HowToSetGoal1 : MonoBehaviour
{
    public void NavigateBackToGoalLogScene()
    {
        // Navigate back to Goal-Log_Scene
        SceneManager.LoadScene("Goal-Log_Scene");
    }

    public void NavigateToHowToSetGoal2Scene()
    {
        // Navigate to HowToSetGoal2_Scene
        SceneManager.LoadScene("HowToSetGoal2_Scene");
    }
}
