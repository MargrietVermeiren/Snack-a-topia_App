using System;

public class Pet 
{
    public DateTime lastTimeFed, lastTimeFriendship;
    public int food, friendship;

    public Pet(DateTime lastTimeFed, DateTime lastTimeFriendship, int food, int friendship)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeFriendship = lastTimeFriendship;
        this.food = food;
        this.friendship = friendship;
    }
}
