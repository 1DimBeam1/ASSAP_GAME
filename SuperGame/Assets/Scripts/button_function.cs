using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Play_button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
  
}