using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CodeScreenController : MonoBehaviour
{
    public List<GameObject> codeObjects; // Assign the code GameObjects in the Inspector
    public Button backButton; // Assign your back button in the Inspector
    private GameObject selectedCodeObject; // Store the selected code object

    void Start()
    {
        if (codeObjects == null || codeObjects.Count == 0)
        {
            Debug.LogError("No code objects assigned! Add code GameObjects to the list.");
            return;
        }

        if (backButton == null)
        {
            Debug.LogError("Back button is not assigned!");
            return;
        }

        // Assign the back button's functionality
        backButton.onClick.AddListener(OnBackButtonPressed);

        // Deactivate all code objects
        foreach (GameObject code in codeObjects)
        {
            code.SetActive(false);
        }

        // Randomly activate one code object
        selectedCodeObject = codeObjects[Random.Range(0, codeObjects.Count)];
        selectedCodeObject.SetActive(true);

        Debug.Log($"Random code activated: {selectedCodeObject.name}");
    }

    private void OnBackButtonPressed()
    {
        Debug.Log("Back button pressed.");

        // Clear the log list from LogManager
        LogManager logManager = FindObjectOfType<LogManager>();
        if (logManager != null)
        {
            logManager.selectedVeggies.Clear(); // Clear the selected veggies list
            Debug.Log("Cleared selected veggies list in LogManager.");
        }
        else
        {
            Debug.LogWarning("LogManager not found when clearing log list.");
        }

        // Go back to the Goal-Log scene
        SceneManager.LoadScene("Goal-Log_Scene");
    }
}
