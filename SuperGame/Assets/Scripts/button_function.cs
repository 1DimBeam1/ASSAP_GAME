using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class button_function : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
   
    public void QuitG()
    {
        Application.Quit();
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
     }

}
