using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    private float Start = 0;
    private float End = 4;
    public void OnHit()
    {
   GetComponent<Rigidbody>().isKinematic = false;
   Start += 0.1f * Time.deltaTime;
        if (Start>=End)
        {
            Destroy (gameObject);
        }
    }
}

