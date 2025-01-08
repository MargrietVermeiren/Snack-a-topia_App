using UnityEngine;


public class LoggingSceneManager : MonoBehaviour
{
    public LogScreenController logScreenController; // Assign in Inspector or find at runtime

    void Start()
    {
        // Option 1: Automatically find the LogScreenController
        if (logScreenController == null)
        {
            logScreenController = FindObjectOfType<LogScreenController>();
        }

        if (logScreenController == null)
        {
            Debug.LogError("LogScreenController not found! Ensure it exists in the scene.");
        }
        else
        {
            Debug.Log("LogScreenController successfully found.");
        }
    }

    public void SaveProgress()
    {
        if (logScreenController != null)
        {
            logScreenController.SaveProgress();
        }
        else
        {
            Debug.LogError("Cannot save progress. LogScreenController is missing!");
        }
    }
}
