using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_HowToSetGoal2 : MonoBehaviour
{
    public void NavigateBackToHowToSetGoal()
    {
        // Navigate back to Goal-Log_Scene
        SceneManager.LoadScene("HowToSetGoal1_Scene");
    }

    public void NavigateToHowToSetGoal3Scene()
    {
        // Navigate to HowToSetGoal2_Scene
        SceneManager.LoadScene("HowToSetGoal3_Scene");
    }
}
