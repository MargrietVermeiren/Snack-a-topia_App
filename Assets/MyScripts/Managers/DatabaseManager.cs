using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    private Database database;
    public NeedsController needsController;

    private void Awake()
    {
        database = new Database();
        if(instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one DatabaseManager in the Scene");
    }

    private void Update()
    {
        if(TimingManager.gameHourTimer < 0)
        {
            Pet pet = new Pet(needsController.lastTimeFed, needsController.lastTimeFriendship, needsController.food, needsController.friendship);

            SavePet(pet);
        }
    }

    private void Start() 
    {
        Pet pet = LoadPet();
        if (pet != null) Debug.Log(LoadPet().friendship);
    }

    public void SavePet(Pet pet)
    {
        database.SaveData<Pet>("pet", pet);
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;
        database.LoadData<Pet>("pet", (pet) =>
        {
            returnValue = pet;
        });
        return returnValue;
    }
}
