using UnityEngine;
using UnityEngine.UI;

public class BackgroundFitter : MonoBehaviour
{
    void Start()
    {
        Image image = GetComponent<Image>();
        RectTransform rt = GetComponent<RectTransform>();

        // Get the screen and image aspect ratios
        float screenAspect = (float)Screen.width / Screen.height;
        float imageAspect = (float)image.sprite.bounds.size.x / image.sprite.bounds.size.y;

        if (screenAspect > imageAspect)
        {
            // Screen is wider, match height and let width overflow
            rt.sizeDelta = new Vector2(0, rt.sizeDelta.y); // Reset width delta
            rt.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // Screen is taller, match width and let height overflow
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, 0); // Reset height delta
            rt.localScale = new Vector3(1, 1, 1);
        }
    }
}

