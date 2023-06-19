using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    private bool hasCollided = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void OnHit()
    {
        if (!hasCollided)
        {
            hasCollided = true;

            // Отримуємо поточну позицію об'єкта
            Vector3 currentPosition = transform.position;

            // Встановлюємо нову позицію зі зміненими координатами
            Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 1f);

            // Змінюємо позицію об'єкта на нову позицію
            transform.position = newPosition;
        }

        GetComponent<Collider>().isTrigger = true;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}