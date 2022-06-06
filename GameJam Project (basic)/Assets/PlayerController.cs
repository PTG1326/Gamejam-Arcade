using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb ;
    public int maxspeed = 7 ;
    public int jumpforce = 10 ;
    public float initialspeed = 5f ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( Input.GetKey("d") ) 
        {
            if ( rb.velocity.x < maxspeed ) 
            {
                rb.AddForce(new Vector2(initialspeed * Time.deltaTime , 0)) ;
            }
        }

        if ( Input.GetKeyUp("d") )
        {
            rb.AddForce((new Vector2(-rb.velocity.x , 0)), ForceMode2D.Impulse) ;
        }

        if ( Input.GetKey("a") && transform.position.x > -8.35 ) 
        {
            if ( rb.velocity.x > -maxspeed ) 
            {
                rb.AddForce(new Vector2(-initialspeed * Time.deltaTime , 0)) ;
            }
        }

        if ( Input.GetKeyUp("a") )
        {
            rb.AddForce((new Vector2(-rb.velocity.x , 0)), ForceMode2D.Impulse) ;
        }


        if ( transform.position.x < -8.35 ) {
            rb.AddForce((new Vector2(-rb.velocity.x , 0)), ForceMode2D.Impulse) ;
        }
    }
}
