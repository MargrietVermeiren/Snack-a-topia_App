using UnityEngine;
using UnityEngine.SceneManagement;

public class NumpadController : MonoBehaviour
{
    private string currentInput = ""; // To store the entered numbers
    private const string correctCode = "1234"; // The correct code
    public GameObject errorText; // Reference to the error text GameObject
    public GameObject[] hollowCircles; // Array for the hollow circle GameObjects
    public GameObject[] filledCircles; // Array for the filled circle GameObjects

    public void AddNumber(string number)
    {
        // Add the number to the current input
        if (currentInput.Length < 4)
        {
            currentInput += number;
            UpdateCircles();

            // Hide error text if it's visible
            if (errorText.activeSelf)
            {
                errorText.SetActive(false);
            }
        }

        // Check if the input is complete
        if (currentInput.Length == 4)
        {
            CheckCode();
        }
    }

    public void Backspace()
    {
        // Remove the last digit if there are any digits
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateCircles();
        }
    }

    private void CheckCode()
    {
        if (currentInput == correctCode)
        {
            // Correct code: Go to the Goal-Log_Scene
            SceneManager.LoadScene("Goal-Log_Scene");
        }
        else
        {
            // Wrong code: Show error text and reset circles
            errorText.SetActive(true);
            ResetCircles();
        }
    }

    private void UpdateCircles()
    {
        // Update the circles based on current input length
        for (int i = 0; i < hollowCircles.Length; i++)
        {
            if (i < currentInput.Length)
            {
                hollowCircles[i].SetActive(false);
                filledCircles[i].SetActive(true);
            }
            else
            {
                hollowCircles[i].SetActive(true);
                filledCircles[i].SetActive(false);
            }
        }
    }

    private void ResetCircles()
    {
        // Reset all circles to hollow state
        currentInput = "";
        for (int i = 0; i < hollowCircles.Length; i++)
        {
            hollowCircles[i].SetActive(true);
            filledCircles[i].SetActive(false);
        }
    }
}
