using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler_Login : MonoBehaviour
{
    public void OpenWebsiteAndLoadScene()
    {
        // Open the website in the default web browser
        Application.OpenURL("https://snack-a-topia.vercel.app/login");

        // Load the Start_Scene in Unity
        SceneManager.LoadScene("Start_Scene");
    }
}
