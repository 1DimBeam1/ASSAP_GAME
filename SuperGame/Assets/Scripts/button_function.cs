using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class button_function : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
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
