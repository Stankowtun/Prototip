using System.Threading;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] GameObject Finish;
    [SerializeField] GameObject GameOver;
    [SerializeField] rot rotationScript; 

    [SerializeField] private int maxNumOfHearts = 3; 
    [SerializeField] private int currentNumOfHearts; 
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private bool isImmortal = false;
    private float immortalDuration = 1f;
    private float currentImmortalTime = 0f;
    private bool isFinished = false;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1;
        currentNumOfHearts = maxNumOfHearts; 
    }

    private void FixedUpdate()
    {
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (isImmortal)
        {
            currentImmortalTime += Time.deltaTime;
            if (currentImmortalTime >= immortalDuration)
            {
                isImmortal = false;
                currentImmortalTime = 0f;
            }
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentNumOfHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxNumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemi"))
        {
            if (!isImmortal)
            {
                currentNumOfHearts--;
                isImmortal = true;
                if (currentNumOfHearts <= 0)
                {
                   
                    Time.timeScale = 0;
                    GameOver.SetActive(true);
                    rotationScript.enabled = false;

                }
            }

            collision.gameObject.GetComponent<Enemi>().OnHit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Finish.SetActive(true);
            Time.timeScale = 0;
            rotationScript.enabled = false; 
        }
    }
}