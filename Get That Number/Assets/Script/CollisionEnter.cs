using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour
{

    private ChangeNumber changeNumScript;



    private void Start()
    {
        changeNumScript = gameObject.GetComponentInParent<ChangeNumber>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        //changeNumScript.InteractWithShellAfterCollision(collision);

        
        if (collision.gameObject.name == "Shell1(Clone)" || collision.gameObject.name == "Shell2(Clone)")
        {
            changeNumScript.InteractWithShellAfterCollision(collision);//if is normal shell just attaches it
        }

        if (collision.gameObject.name == "ResetShell1(Clone)" || collision.gameObject.name == "ResetShell2(Clone)")//問我為什麼要寫這麼繁瑣，爽啦
        {
            changeNumScript.InteractWithShellAfterCollision(collision);
        }

        if (collision.gameObject.name == "AddTimeShell1(Clone)" || collision.gameObject.name == "AddTimeShell2(Clone)")
        {
            changeNumScript.InteractWithShellAfterCollision(collision);
        }

        if (collision.gameObject.name == "AOEshell1(Clone)" || collision.gameObject.name == "AOEshell2(Clone)")
        {
            changeNumScript.InteractWithShellAfterCollision(collision);
        }



        if (collision.gameObject.name == "BarrierShell1(Clone)")//先這樣
        {
            changeNumScript.player2IsNotAllow = 1;
            Debug.Log("shield is collide with me");
            //changeNumScript.AddShieldImage();
        }
        if (collision.gameObject.name == "Barrier2(Clone)")//先這樣
        {
            changeNumScript.player1IsNotAllow = 1;
        }

    }




}
