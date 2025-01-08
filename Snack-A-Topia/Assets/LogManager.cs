using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public List<Sprite> selectedVeggies = new List<Sprite>(); // Store selected veggies as sprites

    private void Awake()
    {
        // Ensure this object persists between scenes
        DontDestroyOnLoad(this);
    }

    // Method to set the selected veggies
    public void SetVeggieList(List<Sprite> veggies)
    {
        selectedVeggies = veggies;
        Debug.Log($"Veggie list updated. Total veggies: {selectedVeggies.Count}");
    }

    // Optional: Method to retrieve the selected veggies if needed
    public List<Sprite> GetVeggieList()
    {
        return selectedVeggies;
    }
}
