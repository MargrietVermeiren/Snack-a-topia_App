using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogScreenControler : MonoBehaviour
{
    public GameObject[] logEntries; // Array of log entry GameObjects (with checkboxes)
    private bool[] checkboxStates; // Array to store checkbox states

    void Start()
    {
        // Initialize and load saved checkbox states
        checkboxStates = new bool[logEntries.Length];
        LoadProgress();
        UpdateCheckboxes();
    }

    public void SaveProgress()
    {
        // Save the current checkbox states
        for (int i = 0; i < logEntries.Length; i++)
        {
            // Assuming each log entry has a CheckedBox GameObject
            GameObject checkedBox = logEntries[i].transform.Find("CheckedBox").gameObject;
            checkboxStates[i] = checkedBox.activeSelf;
            PlayerPrefs.SetInt($"CheckboxState_{i}", checkboxStates[i] ? 1 : 0);
        }

        PlayerPrefs.Save();

        // Check if all boxes are ticked
        if (AllBoxesChecked())
        {
            SceneManager.LoadScene("Code_Scene");
        }
        else
        {
            SceneManager.LoadScene("Goal-Log_Scene");
        }
    }

    private bool AllBoxesChecked()
    {
        foreach (bool state in checkboxStates)
        {
            if (!state) return false;
        }
        return true;
    }

    private void LoadProgress()
    {
        for (int i = 0; i < logEntries.Length; i++)
        {
            // Load the saved state from PlayerPrefs
            checkboxStates[i] = PlayerPrefs.GetInt($"CheckboxState_{i}", 0) == 1;
        }
    }

    private void UpdateCheckboxes()
    {
        for (int i = 0; i < logEntries.Length; i++)
        {
            GameObject checkedBox = logEntries[i].transform.Find("CheckedBox").gameObject;
            GameObject uncheckedBox = logEntries[i].transform.Find("UncheckedBox").gameObject;

            // Update the state of each checkbox
            if (checkboxStates[i])
            {
                checkedBox.SetActive(true);
                uncheckedBox.SetActive(false);
            }
            else
            {
                checkedBox.SetActive(false);
                uncheckedBox.SetActive(true);
            }
        }
    }
}
