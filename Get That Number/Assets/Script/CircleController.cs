using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircleController : MonoBehaviour
{
    public GameObject numBall;
    
    
    public List<GameObject> ballList=new List<GameObject>();
    public List<int> numList = new List<int>();

    private bool startRolling = false;

    [SerializeField]
    private float rollingSpeed = 1f;


    private TextMeshProUGUI desireNumText;
    public int desireNum;
    public int low_limit_d;
    public int high_limit_d;

    private TextMeshProUGUI goal1Text;
    public int goal1;
  
    private TextMeshProUGUI goal2Text;
    public int goal2;

    public int low_limit_p;
    public int high_limit_p;


    public bool gameIsContinue=true;

    private void Start()
    {
        desireNumText = GameObject.Find("DesireNumber").GetComponent<TextMeshProUGUI>();
        desireNum = Random.Range(low_limit_d,high_limit_d);//can't let the number ball share the same number with desire number

        goal1Text = GameObject.Find("Player1Goal").GetComponent<TextMeshProUGUI>();
        goal1 = Random.Range(low_limit_p, high_limit_p);

        goal2Text = GameObject.Find("Player2Goal").GetComponent<TextMeshProUGUI>();
        goal2 = Random.Range(low_limit_p, high_limit_p);

        StartCoroutine(EmittingBallAndText());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (startRolling == true && gameIsContinue)
        {
            transform.Rotate(0f, 0f, 0.1f*rollingSpeed);
            //if (rollingSpeed<=)
            rollingSpeed += 0.0015f;
        }


       
        if (Input.GetKeyDown(KeyCode.A))
        {
            test();
        }
    }


    IEnumerator EmittingBallAndText()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 8; i++)
        {
            
            GameObject newNumBall=Instantiate(numBall, transform.position,transform.rotation );
            ballList.Add(newNumBall);
            for (int j = 0; j < 8; j++)
            {
                numList.Add(newNumBall.GetComponent<ChangeNumber>().numberText_value);
            }
            Debug.Log(ballList.Count);
            
            newNumBall.transform.Rotate(0f, 0f, i * 45f);
            newNumBall.transform.parent = this.gameObject.transform;
            //newNumBall.GetComponent<Rigidbody2D>().velocity = Vector3.forward*10;
            //newNumBall.GetComponent<Rigidbody2D>().MovePosition( Vector3.forward*100*Time.deltaTime);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1f);


            desireNumText.text = desireNum.ToString();

            goal1Text.text = goal1.ToString();

            goal2Text.text = goal2.ToString();
            

        startRolling = true;
       // GameObject.Find("touchscreen1").SetActive(false);
        //GameObject.Find("touchscreen2").SetActive(false);
        //GameObject.Find("ShellManager1").GetComponent<ShellGenerator>().OpenButtonFunction();
        //GameObject.Find("ShellManager2").GetComponent<ShellGenerator>().OpenButtonFunction();
        //start playing from all set up
    }
    void test()
    {
        Debug.Log(ballList.Count);
    }

    public void CaculateInAllBall(string oper, int num, Collider2D collision,GameObject beingHitOne)
    {
        Debug.Log(ballList);
        List<GameObject> new_List = ballList;
        Debug.Log(new_List.Count);
        Debug.Log(ballList[0]);
        Debug.Log("ewerwer");
        /*
        foreach (GameObject numball in ballList)
        {
            Debug.Log("enter caculate loop");
            if (numball != beingHitOne)
            {
                numball.GetComponent<ChangeNumber>().ChangenumberTextValue(oper, num, collision);
                Debug.Log("change!!!");
            }
            else
            {
                continue;
            }

        }*/
        
        for (int i = 0; i < 8; i++)
        {
            Debug.Log("enter loop fefhiu");
            Debug.Log(ballList[i]);
            GameObject numball = ballList[i];
            numball.GetComponent<ChangeNumber>().ChangenumberTextValue(oper, num, collision);
            /*if (numball != beingHitOne)
            {
                numball.GetComponent<ChangeNumber>().ChangenumberTextValue(oper, num, collision);
                Debug.Log("change!!!");
            }
            else
            {
                continue;
            }*/
        }
        Destroy(collision.gameObject);
    }

    public int ResetDesireNum(int former_num)
    {
        Debug.Log("somebody call me");
        do
        {
            desireNum = Random.Range(low_limit_d, high_limit_d);
        } while (desireNum == former_num || numList.Contains(desireNum));
        
        desireNumText.text = desireNum.ToString();

        return desireNum;
        

    }

    public int ResetGoal1(int former_num)
    {
        do
        {
            goal1 = Random.Range(low_limit_p, high_limit_p);
        } while (goal1 == former_num || numList.Contains(goal1));

        goal1Text.text = goal1.ToString();

        return goal1;



    }
    public int ResetGoal2(int former_num)
    {
        do
        {
            goal2 = Random.Range(low_limit_p, high_limit_p);
        } while (goal2 == former_num || numList.Contains(goal2));

        goal2Text.text = goal2.ToString();

        return goal2;



    }





}







