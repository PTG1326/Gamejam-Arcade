using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner_Player_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
     void Update()
    {   
        if(PlayerController.visible == false || FindObjectOfType<PlayerController>().rb.transform.position.y > 97){
            GetComponent<UnityEngine.UI.Text>().text = "Player 2 won. Eat shit player 1 hehe.";
        }
        else if(PlayerController2.visible == false || FindObjectOfType<PlayerController>().rb.transform.position.y > 97){
            GetComponent<UnityEngine.UI.Text>().text = "Player 1 won. Eat shit player 2 hehe.";
        }
    }
}
