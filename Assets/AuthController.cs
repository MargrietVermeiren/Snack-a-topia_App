using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthController : MonoBehaviour
{
    public void OpenLoginPage()
    {
        if (PlayerPrefs.HasKey("UserToken"))
        {
            Debug.Log("User already logged in. Skipping login.");
            SceneManager.LoadScene("Start_Scene");
            return;
        }

        string url = "https://snack-a-topia.vercel.app/api/unity-auth?deep_link=myapp://auth-callback";
        Application.OpenURL(url);
        Debug.Log("Opening login page: " + url);
    }
}

