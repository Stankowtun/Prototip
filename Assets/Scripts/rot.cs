using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    
void Update() 
{

            if (Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0);
 
                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(0f, screenTouch.deltaPosition.x*0.3f, 0f);
                }
 
                
            }
        }
      
 
       
    }   


