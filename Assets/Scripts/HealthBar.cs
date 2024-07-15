using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image FrameBar;

    public void UpdateBar(float currentHealth, float maxHealth)
    {
        FrameBar.fillAmount = currentHealth / maxHealth;
    }
}
