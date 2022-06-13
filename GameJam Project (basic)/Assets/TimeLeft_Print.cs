using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeLeft_Print : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {   
        if(PlayerController.visible == false){
            GetComponent<UnityEngine.UI.Text>().text = Math.Round(PlayerController.offtimecounter, 1).ToString();
        }
        else if(PlayerController2.visible == false){
            GetComponent<UnityEngine.UI.Text>().text = Math.Round(PlayerController2.offtimecounter, 1).ToString();
        }
        else{
           GetComponent<UnityEngine.UI.Text>().text= "Hehe eat dick bitch";
        }
    }
}
