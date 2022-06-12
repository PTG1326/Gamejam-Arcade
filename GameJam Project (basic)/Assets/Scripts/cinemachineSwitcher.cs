using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineSwitcher : MonoBehaviour
{
    public Rigidbody2D p1;
    public Rigidbody2D p2;
    [SerializeField] CinemachineVirtualCamera p1cam;
    [SerializeField] CinemachineVirtualCamera p2cam;
    [SerializeField] CinemachineVirtualCamera normalCam;
    [SerializeField] Camera cam;
    public Transform targetPos;
    //bool normalCamUsed = true;
    public Vector3 viewPos;
    public GameObject camTarget;

    // Start is called before the first frame update
    void Start()
    {
        camTarget = GameObject.Find("cameraTarget");
        
    }

    // Update is called once per frame
    void Update()
    {
        //targetPos = camTarget.transform.position;
        viewPos = cam.WorldToViewportPoint(targetPos.position);

        if(viewPos.y > 0.5)
        {
            if(p1.position.y > p2.position.y)
            {
                //normalCamUsed = false;
                p1cam.Priority = 1;
                p2cam.Priority = 0;
                normalCam.Priority = 0;
                
            }
            
            if(p1.position.y < p2.position.y)
            {
                //normalCamUsed = false;
                p1cam.Priority = 0;
                p2cam.Priority = 1;
                normalCam.Priority = 0;
                
            }
        }
        else
        {
            p1cam.Priority = 0;
            p2cam.Priority = 0;
            normalCam.Priority = 1;
        }
        
    }

    
}
