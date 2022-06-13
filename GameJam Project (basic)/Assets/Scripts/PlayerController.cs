using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool input;
    public LayerMask wallLayer;

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
    public LayerMask wall;    

    private float jumptimeCounter;
    public float jumptime;
    private bool isJumping;

    public float offtime;
    public static float offtimecounter;
    public static bool visible;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    void OnBecameInvisible()
    {
        visible = false;
    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        visible = true;
    }

    // Start is called before the first frame update
    public void Start()
    {
        offtimecounter = offtime;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if ( Input.GetKey("d") ) 
        {
            if ( rb.velocity.x < maxspeed ) 
            {
                rb.AddForce(new Vector2(initialspeed * Time.deltaTime , 0)) ;
                input = true;
            }
        }
        if ( Input.GetKey("a")) 
        {
            if ( rb.velocity.x > -maxspeed ) 
            {
                rb.AddForce(new Vector2(-initialspeed * Time.deltaTime , 0)) ;
                input = true;
            }
        }
    }

    void Update(){

        if ( Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
               rb.velocity = new Vector2(0,rb.velocity.y);
               input = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkradius, groundef) || (Physics2D.OverlapCircle(rightPos.position, checkradius, groundef) || Physics2D.OverlapCircle(leftPos.position, checkradius, groundef));

        if (isGrounded == true && Input.GetKeyDown("w")){
                 rb.AddForce((new Vector2(0 , jumpforce)), ForceMode2D.Impulse) ;
                 isJumping = true;
                 jumptimeCounter = jumptime;
        }

        if(Input.GetKey("w") && isJumping == true){
            if(jumptimeCounter > 0){
                // rb.AddForce((new Vector2(0 , jumpforce)), ForceMode2D.Impulse) ;
               rb.AddForce(new Vector2(0 , jumpforce * Time.deltaTime * 200)) ;
               jumptimeCounter -=  Time.deltaTime;
            }
            else{
                isJumping = false;
            }

        }
        if(Input.GetKeyUp("w")){
            isJumping = false; 
        }

        
        
        if(visible == false){
            if(offtimecounter>0){
               offtimecounter -= Time.deltaTime;
            }
            else{
            FindObjectOfType<GameManager>().gameOver();
            }
        }
        if(visible == true){
            offtimecounter = offtime;
        }
        // isTouchingFront =Physics2D.OverlapCircle(frontCheck.position, checkradius, groundef);

        // if(isTouchingFront == true && isGrounded == false && input==true)
        // {
        //     wallSliding = true;
        // }
        // else
        // {
        //     wallSliding = false;
        // }

        // if(wallSliding == true)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));            
        // }

        
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
