using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoggingSceneManager : MonoBehaviour
{
    public Transform contentArea; // Assign the ScrollView's Content object in the Inspector
    public GameObject logEntryPrefab; // Assign the prefab for log entries in the Inspector
    private LogManager logManager; // Reference to the persistent LogManager
    private GameObject[] logEntries; // Array to store dynamically created log entries
    private bool[] checkboxStates; // Array to store the checkbox states

    void Start()
    {
        // Find the LogManager in the scene
        logManager = FindObjectOfType<LogManager>();

        if (logManager == null)
        {
            Debug.LogError("LogManager not found! Ensure it persists between scenes.");
            return;
        }

        if (logManager.selectedVeggies == null || logManager.selectedVeggies.Count == 0)
        {
            Debug.LogError("Selected veggies list is null or empty!");
            return;
        }

        Debug.Log("Populating log with selected veggies.");

        // Initialize the checkbox states
        checkboxStates = new bool[logManager.selectedVeggies.Count];

        // Populate the log with veggie images
        PopulateLog(logManager.selectedVeggies);

        // Load the saved checkbox states
        LoadProgress();
        UpdateCheckboxes();
    }

    void PopulateLog(List<Sprite> veggieSprites)
    {
        logEntries = new GameObject[veggieSprites.Count]; // Initialize the logEntries array

        for (int i = 0; i < veggieSprites.Count; i++)
        {
            // Instantiate the log entry prefab
            GameObject logEntry = Instantiate(logEntryPrefab, contentArea);
            logEntries[i] = logEntry; // Add to the logEntries array

            // Assign the veggie sprite to the log entry
            Image veggieImage = logEntry.transform.Find("VeggieNameImage").GetComponent<Image>();
            if (veggieImage != null)
            {
                veggieImage.sprite = veggieSprites[i];
            }

            // Initialize the checkbox functionality
            GameObject checkedBox = logEntry.transform.Find("CheckedBox").gameObject;
            GameObject uncheckedBox = logEntry.transform.Find("UncheckedBox").gameObject;

            int index = i; // Cache the index for the closure
            uncheckedBox.GetComponent<Button>().onClick.AddListener(() =>
            {
                checkboxStates[index] = true;
                UpdateCheckboxes();
            });

            checkedBox.GetComponent<Button>().onClick.AddListener(() =>
            {
                checkboxStates[index] = false;
                UpdateCheckboxes();
            });

            checkedBox.SetActive(false); // Start unchecked
            uncheckedBox.SetActive(true);
        }
    }

    private void UpdateCheckboxes()
    {
        for (int i = 0; i < checkboxStates.Length; i++)
        {
            if (logEntries[i] == null) continue;

            GameObject checkedBox = logEntries[i].transform.Find("CheckedBox").gameObject;
            GameObject uncheckedBox = logEntries[i].transform.Find("UncheckedBox").gameObject;

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

    private void LoadProgress()
    {
        for (int i = 0; i < checkboxStates.Length; i++)
        {
            checkboxStates[i] = PlayerPrefs.GetInt($"CheckboxState_{i}", 0) == 1;
        }
    }

    public void SaveProgress()
    {
        for (int i = 0; i < checkboxStates.Length; i++)
        {
            PlayerPrefs.SetInt($"CheckboxState_{i}", checkboxStates[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }
}
