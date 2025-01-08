using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage, friendshipImage;

    public static PetUIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the scene");
    }

    public void UpdateImages(int food, int friendship)
    {
        foodImage.fillAmount = (float) food / 100;
        friendshipImage.fillAmount = (float) friendship / 100;
    }
}
