using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController_ParentsKids : MonoBehaviour
{
    public void GoToParentsScene()
    {
        SceneManager.LoadScene("Verify_Scene");
    }

    public void GoToKidsScene()
    {
        SceneManager.LoadScene("KidsStart_Scene");
    }
}
