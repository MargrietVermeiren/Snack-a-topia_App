using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogScreenController : MonoBehaviour
{
    public Transform contentArea; // Parent container for log entries
    public GameObject logEntryPrefab; // Prefab for log entries
    private List<GameObject> logEntries = new List<GameObject>(); // Store dynamically created log entries
    private bool[] checkboxStates; // Store checkbox states

    void Start()
    {
        Debug.Log("Start method called in LogScreenController.");
        PopulateLogEntries();
        LoadProgress();
        UpdateCheckboxes();
    }

    private void PopulateLogEntries()
    {
        Debug.Log("PopulateLogEntries has been called.");

        LogManager logManager = FindObjectOfType<LogManager>();
        if (logManager == null || logManager.selectedVeggies == null || logManager.selectedVeggies.Count == 0)
        {
            Debug.LogError("No selected veggies found to populate log entries.");
            return;
        }

        Debug.Log($"Populating {logManager.selectedVeggies.Count} log entries...");

        // Initialize checkboxStates array
        checkboxStates = new bool[logManager.selectedVeggies.Count];
        for (int i = 0; i < checkboxStates.Length; i++)
        {
            checkboxStates[i] = false; // Ensure all checkboxes start unchecked
            Debug.Log($"CheckboxState[{i}] initialized to false.");

        }

        // Clear the current log entries list
        logEntries.Clear();

        foreach (Sprite veggieSprite in logManager.selectedVeggies)
        {
            if (veggieSprite == null)
            {
                Debug.LogError("Veggie sprite is null!");
                continue;
            }

            // Instantiate the prefab
            GameObject logEntry = Instantiate(logEntryPrefab);
            if (logEntry == null)
            {
                Debug.LogError("Prefab instantiation failed!");
                continue;
            }

            Debug.Log($"Prefab instantiated: {logEntry.name}");

            // Parent the prefab to the Content area
            logEntry.transform.SetParent(contentArea, false);
            logEntry.transform.localScale = Vector3.one;

            // Assign the veggie sprite to the prefab's VeggieNameImage
            Transform veggieImageTransform = logEntry.transform.Find("VeggieNameImage");
            if (veggieImageTransform != null)
            {
                Image veggieImage = veggieImageTransform.GetComponent<Image>();
                if (veggieImage != null)
                {
                    veggieImage.sprite = veggieSprite;
                    Debug.Log($"Assigned sprite: {veggieSprite.name}");
                }
                else
                {
                    Debug.LogError("VeggieNameImage does not have an Image component!");
                }
            }
            else
            {
                Debug.LogError("VeggieNameImage not found in log entry prefab.");
            }

            // Initialize checkboxes
            GameObject checkedBox = logEntry.transform.Find("CheckedBox")?.gameObject;
            GameObject uncheckedBox = logEntry.transform.Find("UncheckedBox")?.gameObject;

            if (checkedBox == null || uncheckedBox == null)
            {
                Debug.LogError($"Checkbox GameObjects not found in log entry prefab for veggie: {veggieSprite.name}");
                continue;
            }

            // Ensure visual state matches logical state
            checkedBox.SetActive(false);  // Checked state is inactive by default
            uncheckedBox.SetActive(true); // Unchecked state is active by default

            // Add toggle functionality
            int index = logEntries.Count; // Local copy for lambda
            uncheckedBox.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log($"Unchecked box clicked for index {index}");
                checkboxStates[index] = true; // Mark as checked
                UpdateCheckboxes();
            });

            checkedBox.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log($"Checked box clicked for index {index}");
                checkboxStates[index] = false; // Mark as unchecked
                UpdateCheckboxes();
            });

            // Add the log entry to the list
            logEntries.Add(logEntry);
        }

        // Update checkboxes to ensure consistency
        UpdateCheckboxes();
    }




    public void SaveProgress()
    {
        if (checkboxStates == null || checkboxStates.Length == 0)
        {
            Debug.LogError("Checkbox states array is not initialized.");
            return;
        }

        for (int i = 0; i < logEntries.Count; i++)
        {
            PlayerPrefs.SetInt($"CheckboxState_{i}", checkboxStates[i] ? 1 : 0);
        }
        PlayerPrefs.Save();

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
        for (int i = 0; i < checkboxStates.Length; i++)
        {
            checkboxStates[i] = PlayerPrefs.GetInt($"CheckboxState_{i}", 0) == 1;
        }
    }

    private void UpdateCheckboxes()
    {
        for (int i = 0; i < logEntries.Count; i++)
        {
            GameObject checkedBox = logEntries[i].transform.Find("CheckedBox")?.gameObject;
            GameObject uncheckedBox = logEntries[i].transform.Find("UncheckedBox")?.gameObject;

            if (checkedBox == null || uncheckedBox == null) continue;

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
