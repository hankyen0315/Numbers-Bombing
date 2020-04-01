using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellGenerator : MonoBehaviour
{

    public GameObject shell;
    public GameObject numberText;

    public GameObject shieldShell;
    public GameObject resetShell;
    public GameObject addTimeShell;
    public GameObject AOEshell;

    public int restSpaceForShell=15;
    public bool isShellSlotFull=false;
    public bool isAddingShell = false;

    public List<GameObject> shellOnSlot;

 

    // Update is called once per frame
    void Update()
    {
        if (restSpaceForShell>0&&isAddingShell==false)//keep adding new shell until the slot is full
        {
            StartCoroutine(AddShell());
            isAddingShell = true;

        }

    }


    IEnumerator AddShell()
    {
        Debug.Log("adding shell");

        while(restSpaceForShell>0)
        {
            float speed;

            if (GameObject.Find("GameManager").GetComponent<GameManager>().gamingTime >= 8f)
            {
                speed = 1.5f;
            }
            else
            {
                speed = 3.5f;
            }
            int shellID = Random.Range(1, 12);
            GameObject shellToAdd;




            if (shellID < 10)
            {
                shellToAdd = shell;
            }

            /*else if (shellID == 12)
            {
                shellToAdd = shieldShell;
            }*/
            else if (shellID == 10)
            {
                shellToAdd = resetShell;
            }

            else if (shellID == 11)
            {
                shellToAdd = addTimeShell;
            }
            else
            {
                shellToAdd = AOEshell;
            }


            shellToAdd.tag = gameObject.tag;



            Debug.Log(shellID);
            GameObject newShell = Instantiate(shellToAdd, gameObject.transform);//create new shell
            Rigidbody2D newShellRb = newShell.GetComponent<Rigidbody2D>();

            shellOnSlot.Add(newShell);//keep track of every shell
            
            //Debug.Log(newShellRb);
            newShellRb.velocity=(-transform.right*speed);
            yield return new WaitForSeconds(0.5f);
            restSpaceForShell -= 1;
        }
        Debug.Log(shellOnSlot.Count);




        //GameObject newSpecialShell = Instantiate(shieldShell,gameObject.transform);
        //Rigidbody2D SPShellRb = newSpecialShell.GetComponent<Rigidbody2D>();

        //SPShellRb.velocity = (-transform.right * 6f);




        isAddingShell = false;
    }


    public void StartMoving(GameObject shell)
    {
        StartCoroutine(MoveForward(shell));
    }


    IEnumerator MoveForward(GameObject shellBeLaunched)
    {
        Debug.Log(shellOnSlot.IndexOf(shellBeLaunched) + 1);
        if (shellOnSlot.IndexOf(shellBeLaunched) + 1 == shellOnSlot.Count - 1)//if the shell be lanuch is the second last shell
        {
            shellOnSlot[shellOnSlot.IndexOf(shellBeLaunched) + 1].GetComponent<Rigidbody2D>().velocity = -transform.right * 0.6f;
        }
        for (int i = shellOnSlot.IndexOf(shellBeLaunched) + 1; i < shellOnSlot.Count-1; i++)//move forward if the former shell is been launched
        {
            shellOnSlot[i].GetComponent<Rigidbody2D>().velocity = -transform.right * 0.65f;
            yield return new WaitForSeconds(0.45f);
        }
        shellOnSlot.Remove(shellBeLaunched);

    }

    /*public void OpenButtonFunction()
    {
        for (int i = 0; i < 8; i++)
        {
            shellOnSlot[i].GetComponent<ShellMovement>().button.enabled = true;
        }

    }*/




    public void KeepOtherShellFromBeClick(bool isAnyBeingClicked,GameObject shellIsClicked)//only one shell can be select at the same time
    {
        if (isAnyBeingClicked == true)
        {
            foreach (GameObject shell in shellOnSlot)
            {
                if (shell != shellIsClicked)
                {
                    shell.GetComponent<ClickOnButton>().enabled = false;
                    shell.GetComponentInChildren<Button>().enabled = false;
                }
            }
        }
        else
        {
            foreach (GameObject shell in shellOnSlot)
            {
                shell.GetComponent<ClickOnButton>().enabled = true;
                shell.GetComponentInChildren<Button>().enabled = true;
            }

        }
    }



}
