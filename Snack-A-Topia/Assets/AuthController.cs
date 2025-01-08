using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthController : MonoBehaviour
{
    public void OpenLoginPage()
    {
        string url = "https://snack-a-topia.vercel.app/api/unity-auth?deep_link=myapp://auth-callback";
        Application.OpenURL(url);
        Debug.Log("Opening login page: " + url);
    }
}

