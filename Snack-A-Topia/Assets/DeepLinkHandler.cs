using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeepLinkHandler : MonoBehaviour
{
    private string deepLinkUrl;

    void Start()
    {
        // Check if the app was launched with a deep link
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            HandleDeepLink(Application.absoluteURL);
        }

        // Subscribe to deep link activation
        Application.deepLinkActivated += HandleDeepLink;
    }

    private void HandleDeepLink(string url)
    {
        Debug.Log("Received deep link: " + url);
        deepLinkUrl = url;

        // Extract the token from the URL
        string token = GetQueryParameter(url, "token");

        if (!string.IsNullOrEmpty(token))
        {
            Debug.Log("User token received: " + token);
            ProceedToNextScene(token);
        }
        else
        {
            Debug.LogWarning("No token found in deep link.");
        }
    }

    private string GetQueryParameter(string url, string key)
    {
        // Parse the URL to extract the query parameter
        string[] queryParts = url.Split('?');
        if (queryParts.Length > 1)
        {
            string[] parameters = queryParts[1].Split('&');
            foreach (string param in parameters)
            {
                string[] keyValue = param.Split('=');
                if (keyValue.Length == 2 && keyValue[0] == key)
                {
                    return keyValue[1];
                }
            }
        }
        return null;
    }

    private void ProceedToNextScene(string token)
    {
        // Save the token if needed (e.g., PlayerPrefs or a TokenManager)
        PlayerPrefs.SetString("UserToken", token);
        PlayerPrefs.Save();

        // Proceed to the next scene
        SceneManager.LoadScene("Start_Scene");
    }
}

