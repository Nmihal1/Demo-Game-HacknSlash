using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;

    public float healthbarLength;
    // Start is called before the first frame update
    void Start()
    {
        healthbarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealthAdjustment(0);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthbarLength, 20), currentHealth + "/" + maxHealth);
    }

    public void CurrentHealthAdjustment(int adjustment)
    {
        currentHealth += adjustment;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        healthbarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
    }
}
