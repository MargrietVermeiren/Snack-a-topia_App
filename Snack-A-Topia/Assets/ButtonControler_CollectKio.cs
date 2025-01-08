using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_CollectKio : MonoBehaviour
{
    public void GoToGames()
    {
        // Navigate back to Start_Scene
        SceneManager.LoadScene("Game_Scene");
    }
}
