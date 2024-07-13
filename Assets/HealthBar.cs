using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Image fillImage;

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        fillImage.color = new Color(0, 250, 0);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        if (health < healthSlider.maxValue / 2)
        {
            fillImage.color = Color.yellow;
        }
        if (health < healthSlider.maxValue / 4)
        {
            fillImage.color = Color.red;
        }
    }
}
