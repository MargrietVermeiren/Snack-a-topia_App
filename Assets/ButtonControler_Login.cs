using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler_Login : MonoBehaviour
{
    // URL of the website to open
    private string websiteURL = "https://snack-a-topia.vercel.app/login";

    // Method to open the website and then move to the next scene
    public void GoToWebsiteAndNextScene()
    {
        // Open the website
        Application.OpenURL(websiteURL);
        Debug.Log("Opened website: " + websiteURL);

        // Move to the next scene (Start_Scene)
        SceneManager.LoadScene("Start_Scene");
        Debug.Log("Moved to scene: Start_Scene");
    }
}
