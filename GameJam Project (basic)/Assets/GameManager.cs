using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverCanvas;
    public GameObject gameStartCanvas;

    public void start(){
        FindObjectOfType<PlayerController>().Start();
        FindObjectOfType<PlayerController2>().Start();  
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        gameStartCanvas.SetActive(false);  
        
        }
    
    public void gameOver(){

        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("GameOver"); 
    }

    public void Restart(){
        start();
        Debug.Log("Restart'"); 

    }
}
