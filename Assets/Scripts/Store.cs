using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;
    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        scoreText.text = ((int)(player.position.z / 2)).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            score -= 10;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}