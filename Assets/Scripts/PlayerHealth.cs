using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public float immortalDuration = 1f;

    private int currentLives;
    private bool isImmortal;
    private float immortalTimer;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void Update()
    {
        if (isImmortal)
        {
            immortalTimer -= Time.deltaTime;
            if (immortalTimer <= 0f)
            {
                isImmortal = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemi"))
        {
            if (!isImmortal)
            {
                TakeDamage();
                if (currentLives <= 0)
                {
                    Die();
                }
                else
                {
                    StartImmortalTimer();
                }
            }
        }
    }

    private void TakeDamage()
    {
        currentLives--;
        Debug.Log("Lives: " + currentLives);
    }

    private void Die()
    {
        // Ваш код для обробки смерті гравця
        Debug.Log("Game Over");
    }

    private void StartImmortalTimer()
    {
        isImmortal = true;
        immortalTimer = immortalDuration;
    }
}
