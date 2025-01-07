using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public List<Sprite> selectedVeggies = new List<Sprite>();

    public void SetVeggieList(List<Sprite> veggies)
    {
        selectedVeggies = new List<Sprite>(veggies);
    }
}
