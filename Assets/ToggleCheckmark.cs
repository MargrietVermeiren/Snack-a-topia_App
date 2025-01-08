using UnityEngine;

public class ToggleCheckmark : MonoBehaviour
{
    public GameObject checkmarkButton; // The button with the checkmark
    public GameObject boxButton; // The button without the checkmark

    // Called when the unchecked (box) button is clicked
    public void EnableCheckmark()
    {
        checkmarkButton.SetActive(true);
        boxButton.SetActive(false);
    }

    // Called when the checked (checkmark) button is clicked
    public void DisableCheckmark()
    {
        checkmarkButton.SetActive(false);
        boxButton.SetActive(true);
    }
}
