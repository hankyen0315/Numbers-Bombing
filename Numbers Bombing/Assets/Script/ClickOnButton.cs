using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnButton : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform originalPosition;
    private Vector3 ori_position;

    public Transform desirePosition;//
    private Vector3 position;//real destinition

    private bool isBeingSelect = false;

    public CanonController canon;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        position = desirePosition.position;
        if (this.gameObject.tag == "player1")
        {
            canon = GameObject.Find("Canon1").GetComponent<CanonController>();
        }
        else
        {
            canon = GameObject.Find("Canon2").GetComponent<CanonController>();
        }



    }


    private void Update()
    {


        if (gameObject.transform.position.y >= position.y)
        {
            if (gameObject.transform.localScale.x > 0.18)//just being select ,not ready to be launched
            {
                rb.velocity = Vector2.zero;
            }           
        }
        if (isBeingSelect == false&&rb.velocity == Vector2.zero&&transform.position.y<0.1)
        {
            ori_position = transform.position;
        }
       /* if (isBeingSelect == true && gameObject.transform.position.y < ori_position.y)
        {
            rb.velocity = Vector2.zero;
            isBeingSelect = false;
            Debug.Log("reach down");
        }*/

    }




    public void ReactionAfterTouch()
    {
        if (isBeingSelect == false)
        {
            canon.CheckIfNeedToReplace();
            isBeingSelect = true;//is touched then lift up
            
            rb.velocity = new Vector2(0f, 3f);
            gameObject.transform.localScale = gameObject.transform.localScale * 1.6f;
            canon.shellToFire = this.gameObject;

        }
        else
        {
            canon.shellToFire = null;
            gameObject.transform.localScale = gameObject.transform.localScale * 0.625f;
            Debug.Log("go back to original place");
            gameObject.transform.position= ori_position;
            isBeingSelect = false;
            
        }


        
    }
    






}
