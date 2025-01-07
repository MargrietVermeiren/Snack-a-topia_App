using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoggingSceneManager : MonoBehaviour
{
    public Transform contentArea; // Assign the ScrollView's Content object in the Inspector
    public GameObject logEntryPrefab; // Assign the prefab for log entries in the Inspector
    private LogManager logManager; // Reference to the persistent LogManager

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

        // Populate the log with veggie images and toggle functionality
        PopulateLog(logManager.selectedVeggies);
    }

    void PopulateLog(List<Sprite> veggieSprites)
    {
        foreach (Sprite veggieSprite in veggieSprites)
        {
            // Instantiate a log entry
            GameObject logEntry = Instantiate(logEntryPrefab, contentArea);
            Debug.Log($"Instantiated log entry: {logEntry.name}");

            // Assign the veggie image
            Image veggieImage = logEntry.transform.Find("VeggieNameImage").GetComponent<Image>();
            if (veggieImage != null)
            {
                veggieImage.sprite = veggieSprite;
            }
            else
            {
                Debug.LogError("VeggieNameImage not found in log entry prefab!");
            }

            // Get CheckedBox and UncheckedBox
            Button checkedBox = logEntry.transform.Find("CheckedBox").GetComponent<Button>();
            Button uncheckedBox = logEntry.transform.Find("UncheckedBox").GetComponent<Button>();

            if (checkedBox == null || uncheckedBox == null)
            {
                Debug.LogError("CheckedBox or UncheckedBox not found in log entry prefab!");
                continue;
            }

            // Default state: unchecked
            checkedBox.gameObject.SetActive(false);
            uncheckedBox.gameObject.SetActive(true);

            // Add toggle functionality
            uncheckedBox.onClick.AddListener(() =>
            {
                checkedBox.gameObject.SetActive(true);
                uncheckedBox.gameObject.SetActive(false);
            });

            checkedBox.onClick.AddListener(() =>
            {
                checkedBox.gameObject.SetActive(false);
                uncheckedBox.gameObject.SetActive(true);
            });
        }
    }
}
