using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private Image fillImage = null;

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        slider.value = (float)currentHealth / maxHealth;
        if (fillImage != null && slider.value <= 0)
        {
            fillImage.color = new Color(fillImage.color.r, fillImage.color.g, fillImage.color.b, 0);
        }
    }
}
