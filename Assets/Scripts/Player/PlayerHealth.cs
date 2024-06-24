using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    public TMP_Text healthText;
    public Image healthBar;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UIUpdate();
    }

    void UIUpdate()
    {
        healthBar.fillAmount = currentHealth / 100f;
        healthText.text = ((float)currentHealth / (float)maxHealth * 100).ToString("F0") + "%";
    }

    void Die()
    {
        print("Le player est mort");
    }
}
