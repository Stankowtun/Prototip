using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private int collisionCount = 0; // Лічильник зіткнень
    private int maxCollisionCount = 3; // Максимальна кількість зіткнень до завершення гри

    private void OnCollisionEnter(Collision collision)
    {
        // Перевіряємо, чи зіткнення відбувається з іншими об'єктами
        if (collision.gameObject.CompareTag("OtherObject"))
        {
            // Збільшуємо лічильник зіткнень
            collisionCount++;

            // Перевіряємо, чи досягнуто максимальну кількість зіткнень
            if (collisionCount >= maxCollisionCount)
            {
                // Викликаємо метод, що завершує гру
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        // Ваш код для завершення гри
        Debug.Log("Гра завершена!");
    }
}
