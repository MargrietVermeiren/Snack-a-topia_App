using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeggieSelector : MonoBehaviour
{
    public List<string> selectedVeggies = new List<string>(); // To store selected veggies
    public Button nextButton; // Reference to your "Next" button
    private LogManager logManager; // Reference to LogManager
    public Color selectedColor = Color.green; // Color for selected veggies
    public Color defaultColor = Color.white; // Default color for unselected veggies
    private Dictionary<string, Sprite> veggieSpriteMapping;

    // Declare fields for each veggie sprite
    public Sprite artichokeSprite;
    public Sprite asparagusSprite;
    public Sprite beetrootSprite;
    public Sprite bellPepperSprite;
    public Sprite broccoliSprite;
    public Sprite brusselsSproutSprite;
    public Sprite cabbageSprite;
    public Sprite carrotSprite;
    public Sprite cauliflowerSprite;
    public Sprite celerySprite;
    public Sprite cornSprite;
    public Sprite cucumberSprite;
    public Sprite eggplantSprite;
    public Sprite fennelSprite;
    public Sprite garlicSprite;
    public Sprite greenBeansSprite;
    public Sprite kaleSprite;
    public Sprite leekSprite;
    public Sprite lettuceSprite;
    public Sprite mushroomSprite;
    public Sprite okraSprite;
    public Sprite onionSprite;
    public Sprite parsnipSprite;
    public Sprite peasSprite;
    public Sprite potatoSprite;
    public Sprite pumpkinSprite;
    public Sprite radishSprite;
    public Sprite spinachSprite;
    public Sprite sweetPotatoSprite;
    public Sprite tomatoSprite;
    public Sprite turnipSprite;
    public Sprite zucchiniSprite;


    void Start()
    {
        veggieSpriteMapping = new Dictionary<string, Sprite>
        {
            { "Artichoke", artichokeSprite },
            { "Asparagus", asparagusSprite },
            { "Beetroot", beetrootSprite },
            { "Bell Pepper", bellPepperSprite },
            { "Broccoli", broccoliSprite },
            { "Brussels Sprout", brusselsSproutSprite },
            { "Cabbage", cabbageSprite },
            { "Carrot", carrotSprite },
            { "Cauliflower", cauliflowerSprite },
            { "Celery", celerySprite },
            { "Corn", cornSprite },
            { "Cucumber", cucumberSprite },
            { "Eggplant", eggplantSprite },
            { "Fennel", fennelSprite },
            { "Garlic", garlicSprite },
            { "Green Beans", greenBeansSprite },
            { "Kale", kaleSprite },
            { "Leek", leekSprite },
            { "Lettuce", lettuceSprite },
            { "Mushroom", mushroomSprite },
            { "Okra", okraSprite },
            { "Onion", onionSprite },
            { "Parsnip", parsnipSprite },
            { "Peas", peasSprite },
            { "Potato", potatoSprite },
            { "Pumpkin", pumpkinSprite },
            { "Radish", radishSprite },
            { "Spinach", spinachSprite },
            { "Sweet Potato", sweetPotatoSprite },
            { "Tomato", tomatoSprite },
            { "Turnip", tomatoSprite },
            { "Zucchini", zucchiniSprite }
        };

        Debug.Log($"Manual veggie mapping complete. Loaded {veggieSpriteMapping.Count} entries.");
    

    logManager = FindObjectOfType<LogManager>();

        if (logManager == null)
        {
            Debug.LogError("LogManager not found! Ensure it's in the scene and enabled.");
        }

        if (nextButton == null)
        {
            Debug.LogError("Next Button is not assigned in the Inspector!");
        }
        else
        {
            nextButton.onClick.AddListener(SaveSelections); // Attach the SaveSelections method to the Next button
        }
    }

    public void ToggleSelection(Button veggieButton)
    {
        if (veggieButton == null)
        {
            Debug.LogError("Veggie Button reference is null!");
            return;
        }

        // Use the GameObject's name as the veggie identifier
        string veggieName = veggieButton.gameObject.name;

        // Check if the veggie is already selected
        if (selectedVeggies.Contains(veggieName))
        {
            // Deselect the veggie immediately
            selectedVeggies.Remove(veggieName);
            SetButtonColor(veggieButton, false); // Deselect this button
        }
        else
        {
            // Select the veggie immediately
            selectedVeggies.Add(veggieName);
            SetButtonColor(veggieButton, true); // Highlight this button
        }

        // Debug: Print the current selected veggies
        Debug.Log($"Current selected veggies: {string.Join(", ", selectedVeggies)}");
    }

    private void SetButtonColor(Button button, bool isSelected)
    {
        if (button == null)
        {
            Debug.LogError("Button is null in SetButtonColor!");
            return;
        }

        // Access the Image component of the button and update its color
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = isSelected ? selectedColor : defaultColor;
        }
        else
        {
            Debug.LogError("Button does not have an Image component!");
        }
    }

    private void SaveSelections()
    {
        if (logManager != null)
        {
            // Collect the selected veggie sprites
            List<Sprite> selectedSprites = new List<Sprite>();
            foreach (string veggieName in selectedVeggies)
            {
                Sprite veggieSprite = GetVeggieSpriteByName(veggieName);
                if (veggieSprite != null)
                {
                    selectedSprites.Add(veggieSprite);
                }
            }

            logManager.SetVeggieList(selectedSprites);
            Debug.Log("Selected veggie sprites saved.");

            DontDestroyOnLoad(logManager);
        }
        else
        {
            Debug.LogError("LogManager is null!");
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("LogVegetables");
    }

    private Sprite GetVeggieSpriteByName(string name)
    {
        if (veggieSpriteMapping.ContainsKey(name))
        {
            return veggieSpriteMapping[name];
        }
        else
        {
            Debug.LogError($"Veggie name '{name}' not found in sprite mapping!");
            return null; // Or return a default sprite if desired
        }
    }

}
