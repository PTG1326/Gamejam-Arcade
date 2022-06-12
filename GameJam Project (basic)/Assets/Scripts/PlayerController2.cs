using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public Rigidbody2D rb ;
    public int maxspeed = 7 ;
    public float initialspeed = 5f ;

    public int jumpforce = 10 ;
    private bool isGrounded ;
    public Transform feetPos;
    public Transform rightPos;
    public Transform leftPos;
    public float checkradius;
    public LayerMask groundef;    

    private float jumptimeCounter;
    public float jumptime;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ( Input.GetKey(KeyCode.RightArrow) ) 
        {
            if ( rb.velocity.x < maxspeed ) 
            {
                rb.AddForce(new Vector2(initialspeed * Time.deltaTime , 0)) ;
            }
        }
        if ( Input.GetKey(KeyCode.LeftArrow)) 
        {
            if ( rb.velocity.x > -maxspeed ) 
            {
                rb.AddForce(new Vector2(-initialspeed * Time.deltaTime , 0)) ;
            }
        }
    }

    void Update(){

        if ( Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
               rb.velocity = new Vector2(0,rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkradius, groundef) || (Physics2D.OverlapCircle(rightPos.position, checkradius, groundef) || Physics2D.OverlapCircle(leftPos.position, checkradius, groundef));

        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)){
                 rb.AddForce((new Vector2(0 , jumpforce)), ForceMode2D.Impulse) ;
                 isJumping = true;
                 jumptimeCounter = jumptime;
        }

        if(Input.GetKey(KeyCode.UpArrow) && isJumping == true){
            if(jumptimeCounter > 0){
                // rb.AddForce((new Vector2(0 , jumpforce)), ForceMode2D.Impulse) ;
               rb.AddForce(new Vector2(0 , jumpforce * Time.deltaTime * 200)) ;
               jumptimeCounter -=  Time.deltaTime;
            }
            else{
                isJumping = false;
            }

        }
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            isJumping = false; 
        }

        
        // if ( transform.position.x < -8.49 ) {
        //     rb.AddForce((new Vector2(-rb.velocity.x , 0)), ForceMode2D.Impulse) ;
        //     transform.position = new Vector2(-8.47f, transform.position.y);
        // }
        // if(transform.position.x> 8.45 ){
        //     rb.AddForce((new Vector2(-rb.velocity.x , 0)), ForceMode2D.Impulse) ;
        //     transform.position = new Vector2(8.43f, transform.position.y);
        // }

    }
}
