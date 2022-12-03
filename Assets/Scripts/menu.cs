using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class menu : MonoBehaviour
{
  
 
   public void PlayGame()
   {
     SceneManager.LoadScene(1);
   }
   public void ExitGame()
   {
    Application.Quit();
   }
  public void Shop()
  {
    SceneManager.LoadScene(3);
  }
  public void ExidShop()
  {
    SceneManager.LoadScene(0);
  }
}
