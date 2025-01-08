using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, friendship;
    public int foodTickRate, friendshipTickRate;
    public DateTime lastTimeFed, lastTimeFriendship;

    public void Initialize(int food, int friendship, int foodTickRate, int friendshipTickRate)
    {
        lastTimeFed = DateTime.Now;
        lastTimeFriendship = DateTime.Now;
        this.food = food;
        this.friendship = friendship;
        this.foodTickRate = foodTickRate;
        this.friendshipTickRate = friendshipTickRate;
        PetUIController.instance.UpdateImages(food, friendship);
    }

    private void Update()
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeFriendship(-friendshipTickRate);
            PetUIController.instance.UpdateImages(food, friendship);
        }
    }
    public void ChangeFood(int amount)
    {
        food += amount;
        if (amount > 0)
        {
            lastTimeFed = DateTime.Now;
        }
        if(food < 0)
        {
            PetManager.instance.Die();
        } else if (food > 100) food = 100;
    }

    public void ChangeFriendship(int amount)
    {
        friendship += amount;
        if(amount > 0)
        {
            lastTimeFriendship = DateTime.Now;
        }
        if(friendship < 0)
        {
            PetManager.instance.Die();
        } else if (friendship > 100) friendship = 100;
    }
}
