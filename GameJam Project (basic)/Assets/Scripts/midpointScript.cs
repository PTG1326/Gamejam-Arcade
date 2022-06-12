    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class midpointScript : MonoBehaviour
{
    public Rigidbody2D p1;
    public Rigidbody2D p2;
    //public GameObject camTarget;
    //[SerializeField] Camera cam;
    


    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        //cam = GetComponent<Camera>();
        //camTarget = GameObject.Find("cameraTarget");
        //transform.position = Vector3.Lerp(p1.transform.position, p2.transform.position, 0.5f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 viewPos = cam.WorldToViewportPoint(targetPos);
        
        targetPos = Vector3.Lerp(p1.transform.position, p2.transform.position, 0.5f); 

        
        
        transform.position = targetPos;
        
    }

    
    
    


}
