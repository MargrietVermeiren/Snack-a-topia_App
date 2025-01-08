using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_HowToSetGoal3 : MonoBehaviour
{
    public void NavigateBackToHowToSetGoal2()
    {
        // Navigate back to Goal-Log_Scene
        SceneManager.LoadScene("HowToSetGoal2_Scene");
    }

    public void NavigateToSelectVegetablesScene()
    {
        // Navigate to SelectVegetables_Scene
        SceneManager.LoadScene("SelectVegetables_Scene");
    }
}
