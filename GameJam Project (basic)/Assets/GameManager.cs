using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverCanvas;
    //public string winner_string = "";

    public void start(){
        FindObjectOfType<PlayerController>().Start();
        FindObjectOfType<PlayerController2>().Start();  
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene1"); 
        
        }
    
    public void gameOver(){
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart(){
        SceneManager.LoadScene("SampleScene");
    }
}
