using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{

    private Rigidbody2D rb;

    private float original_Z_rotation;
    private int rotateDirectionNum = 1;


    public GameObject shellToFire;
    public Transform firePoint;

    public float shootingSpeed = 100f;
    public float rotateSpeed = 0.6f;

    private ShellGenerator shellManager;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        original_Z_rotation = transform.rotation.z;
        if (this.gameObject.name == "Canon1")
        {
            shellManager = GameObject.Find("ShellManager1").GetComponent<ShellGenerator>();
        }
        else
        {
            shellManager = GameObject.Find("ShellManager2").GetComponent<ShellGenerator>();
        }
    }


    private void Update()
    {
        bool isAnyBeingClicked=false;
        if (shellToFire != null)
        {
            isAnyBeingClicked = true;
        }
        //shellManager.KeepOtherShellFromBeClick(isAnyBeingClicked, shellToFire);
    }


    private void FixedUpdate()
    {

        //Debug.Log(transform.rotation.z);
        //Debug.Log(original_Z_rotation);

        if (original_Z_rotation-transform.rotation.z >= 0.55f)
        {
            rotateDirectionNum *= -1;
            //Debug.Log("turn left");
        }
        
        if (original_Z_rotation-transform.rotation.z <= -0.55f)
        {
            rotateDirectionNum *= -1;
            //Debug.Log("turn right");
        }
        transform.Rotate(0f, 0f, rotateSpeed * rotateDirectionNum);
        rotateSpeed += 0.0005f;
      
    }



    public void CheckIfNeedToReplace()//if new shell is being select then change shellToFire gameObject
    {
        Debug.Log("enter void ");
        if (shellToFire != null)
        {
            
            shellToFire.GetComponent<ClickOnButton>().ReactionAfterTouch();
            Debug.Log("call the function");

        }


    }


    public void FireShell()
    {
        if (shellToFire != null)
        {
            Debug.Log("shell is going to be launched");

            shellToFire.transform.position = firePoint.position;
            shellToFire.transform.rotation = firePoint.rotation;
            shellToFire.transform.localScale = shellToFire.transform.localScale * 0.625f;

            Debug.Log(shellToFire.GetComponent<Rigidbody2D>());
            //shellToFire.GetComponent<Rigidbody2D>().AddForce(shellToFire.transform.up*shootingSpeed);
            shellToFire.GetComponent<Rigidbody2D>().velocity = shellToFire.transform.up * shootingSpeed;
            shellManager.StartMoving(shellToFire);
            shellToFire = null;
            shellManager.restSpaceForShell += 1;
            
        }

    }








}
