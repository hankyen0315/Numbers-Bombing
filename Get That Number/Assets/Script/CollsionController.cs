using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionController : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity==Vector2.zero)
        {
            gameObject.GetComponent<ShellMovement>().rotateSpeed = 2f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag )
        {

            /*if (collision.gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                //rb.velocity pr= Vector2.zero;
                rb.velocity=collision.gameObject.GetComponent<Rigidbody2D>().
                gameObject.GetComponent<ShellMovement>().rotateSpeed = 2f;
            }*/
            if (rb.velocity.magnitude > collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
            {

                rb.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            }
            
            //gameObject.GetComponent<ShellMovement>().rotateSpeed = collision.gameObject.GetComponent<ShellMovement>().rotateSpeed;


        }
        if (collision.gameObject.tag == "edge")
        {
            rb.velocity = Vector2.zero;
            //gameObject.GetComponent<ShellMovement>().rotateSpeed = 2f;
        }



        if (collision.gameObject.name=="ColliderCheck")
        {
            Debug.Log("hit on circle");
            rb.velocity = Vector2.zero;
            gameObject.GetComponent<ShellMovement>().DestroyExplosion();
        }

        /*if (collision.gameObject.name == "InternalCollision")
        {
            Debug.Log("hit on ball attached to circle");
            rb.velocity = Vector2.zero;
            gameObject.GetComponent<ShellMovement>().DestroyExplosion();
        }*/

    }





    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "edge"||collision.gameObject.tag==gameObject.tag)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {

            }
            rb.velocity = Vector2.zero;
        

        }
        gameObject.GetComponent<ShellMovement>().rotateSpeed = 2f;





    }*/












}
