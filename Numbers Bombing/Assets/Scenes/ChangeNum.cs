using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNum : MonoBehaviour
{
    public TextMeshPro numberText;
    public int numberText_value;

    public int initNum;
    private int desireNum;


    public GameObject attachPoint;
    [SerializeField]
    private int shellAmount = 0;

    private GameObject MainCircle;
    private GameObject gameManager;



    public int player1IsNotAllow = 0;
    public int player2IsNotAllow = 0;

    public List<GameObject> childrenList;
    [SerializeField]
    private int currentChildAmount = 0;

    //for shield shell
    public GameObject shieldImage;
    //for popuptext
    public TextMeshPro popText;
    public Animator textAnimator;



    // Start is called before the first frame update
    void Start()
    {
        numberText = gameObject.GetComponentInChildren<TextMeshPro>();
        desireNum = GameObject.Find("RollingCircle").GetComponent<CircleController>().desireNum;

        initNum = Random.Range(-10, 10);
        if (initNum == desireNum)
        {
            initNum += Random.Range(1, 5);//can't let the number ball share the same number with desire number
        }


        numberText.color = new Color32(255, 255, 255, 255);



        numberText.text = initNum.ToString();
        if (int.TryParse(numberText.text, out int value))
        {
            numberText_value = value;//turn string into int
            Debug.Log("value is vaild");
        }

        gameManager = GameObject.Find("GameManager");
        MainCircle = GameObject.Find("RollingCircle");
    }



    /*private void Update()
    {
        if (childrenList.Count == 0)
        {
            attachPoint.transform.position = new Vector3(0f, 1f, 0f);
            currentChildAmount = 0;
        }
    }*/






    public void InteractWithShellAfterCollision(Collider2D collision)
    {
        Debug.Log("what the");
        //NORMAL SHELL
        if ((collision.gameObject.name == "Shell1(Clone)" && player1IsNotAllow == 0) || (collision.gameObject.name == "Shell2(Clone)" && player2IsNotAllow == 0))
        {
            Debug.Log("omg");
            if (shellAmount < 6)
            {

                GameObject shell = collision.gameObject;
                bool isAttachable = ChangenumberTextValue(shell.GetComponent<ShellData>().oper, shell.GetComponent<ShellData>().numberTextValue, collision);
                //get the shell data that is hitting the ball and caculate it

            }
        }
        //RESET　SHELL
        else if (collision.gameObject.name == "ResetShell1(Clone)" || collision.gameObject.name == "ResetShell2(Clone)")
        {

            Debug.Log("yeah");
            Debug.Log(gameObject.GetComponentsInChildren<ShellMovement>());

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            foreach (ShellMovement childShell in gameObject.GetComponentsInChildren<ShellMovement>())
            {
                childShell.DestroyExplosion();
            }
            collision.gameObject.GetComponent<ShellMovement>().DestroyExplosion();

            shellAmount = 0;
            attachPoint.transform.localPosition = new Vector3(0f, 1f, 0f);
            numberText_value = 0;
            numberText.text = numberText_value.ToString();

        }
        //ADDTIME SHELL
        else if (collision.gameObject.name == "AddTimeShell1(Clone)" || collision.gameObject.name == "AddTimeShell2(Clone)")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (collision.gameObject.tag == "player1")
            {
                GameObject.Find("FireButton2").GetComponent<Cooldown>().CoolDownAfterBeingClick(5);
            }
            else
            {
                GameObject.Find("FireButton1").GetComponent<Cooldown>().CoolDownAfterBeingClick(5);
            }
            collision.gameObject.GetComponent<ShellMovement>().DestroyExplosion();
        }
        //AOESHELL
        else if (collision.gameObject.name == "AOEshell1(Clone)" || collision.gameObject.name == "AOEshell2(Clone)")
        {
            Debug.Log("omg");
            if (shellAmount < 6)
            {
                Debug.Log(MainCircle.GetComponent<CircleController>().ballList.Count);
                GameObject shell = collision.gameObject;

                MainCircle.GetComponent<CircleController>().CaculateInAllBall(shell.GetComponent<ShellData>().oper, shell.GetComponent<ShellData>().numberTextValue, collision, this.gameObject);

                shell.GetComponent<ClickOnButton>().enabled = false;
                shell.GetComponent<CollsionController>().enabled = false;//turn off the shell original function
                shell.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                shell.GetComponent<CircleCollider2D>().enabled = false;

            }
            else
            {
                Destroy(collision.gameObject);
            }


        }



        else//barr
        {
            Debug.Log("oh shit");
            if (player1IsNotAllow != 0)
            {
                player1IsNotAllow -= 1;
            }
            else
            {
                player2IsNotAllow -= 1;
            }


        }

    }
    public bool ChangenumberTextValue(string oper, int num, Collider2D collision)
    {
        string player = collision.gameObject.tag;

        bool isAttachable = false;

        if (int.TryParse(numberText.text, out int value))
        {
            numberText_value = value;//turn string into int
            Debug.Log("value is vaild");
        }

        string num_str = num.ToString();

        switch (oper)
        {


            case "+":
                numberText_value += num;
                isAttachable = true;
                popText.text = "+" + num;
                popText.color = new Color32(255, 0, 0, 255);
                textAnimator.Play("Text_fading_inandout");
                //textAnimator.SetBool("fading", true);
                break;
            case "-":
                numberText_value -= num;
                isAttachable = true;
                popText.text = "-" + num;
                popText.color = new Color32(0, 255, 0, 255);
                textAnimator.Play("Text_fading_inandout");
                //textAnimator.SetBool("fading", true);
                break;
            case "x":
                numberText_value *= num;
                isAttachable = true;
                popText.text = "x" + num;
                popText.color = new Color32(255, 0, 255, 255);
                textAnimator.Play("Text_fading_inandout");
                //textAnimator.SetBool("fading", true);
                break;
            case "÷":
                if (numberText_value % num != 0)
                {
                    Debug.Log("you can't do that");
                    collision.gameObject.GetComponent<ShellMovement>().DestroyExplosion();
                    isAttachable = false;
                    break;
                }
                numberText_value /= num;
                popText.text = "÷" + num;
                popText.color = new Color32(255, 255, 0, 255);
                textAnimator.Play("Text_fading_inandout");
                //textAnimator.SetBool("fading", true);
                break;
        }

        numberText.text = numberText_value.ToString();

        gameManager.GetComponent<GameManager>().CheckIfGameOver(numberText_value, player);
        return isAttachable;
    }

    public void DisableText()
    {
        popText.enabled = false;
    }

    public void ChangeBoolOfAnim()
    {
        //textAnimator.SetBool("fading", false);
    }


    public void AddShieldImage()
    {

        Debug.Log(childrenList);
        foreach (GameObject shell in childrenList)
        {
            Debug.Log(shell);
            GameObject newImage = Instantiate(shieldImage, shell.transform);

            newImage.transform.parent = shell.transform;
        }

    }
}
