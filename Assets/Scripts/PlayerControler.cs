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
   
    
    private CharacterController controller;
    
    
    
void Start()
{
    controller = GetComponent<CharacterController>();
     Time.timeScale = 1;
    
}
    private void FixedUpdate()
    {
       controller.Move(moveDirection * Time.deltaTime);
     if (Input.GetKey(KeyCode.R))
       {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
       
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.GetComponent<Enemi>())
      {
            collision.gameObject.GetComponent<Enemi>().OnHit();
      }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
        Finish.SetActive(true);
        Time.timeScale = 0;
        }
        
    }
    




}
