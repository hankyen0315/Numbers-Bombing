using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    private bool GameOver=false;

    [SerializeField]
    private int desireNum;
    [SerializeField]
    private int goal1;
    [SerializeField]
    private int goal2;


    [SerializeField]
    private int player1Point = 0;
    [SerializeField]
    private int player2Point = 0;
    private int winningPoint = 3;

    private bool enterSecondPhase = false;

    public float gamingTime = 0f;

    public bool isGamePaused = false;
    public GameObject pauseScreen;
    public GameObject pauseButton;

    private Animator anim;



    public TextMeshProUGUI countdownText;
    //public Text countdownText;

    public GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTargetsNum());

        StartCoroutine(StartCountdown());

       

    }

    // Update is called once per frame
    void Update()
    {
        gamingTime += Time.deltaTime;
        if (gamingTime >= 180f)
        {
            Debug.Log("has been playing for two minutes");
            enterSecondPhase = true;
        }
    }

    IEnumerator GetTargetsNum()
    {
        yield return new WaitForSeconds(1f);
        
        /*if (int.TryParse(GameObject.Find("DesireNumber").GetComponent<TextMeshProUGUI>().text, out int num))
        {
            desireNum = num;
            yield return null;
        }*/
        desireNum = GameObject.Find("RollingCircle").GetComponent<CircleController>().desireNum;
        goal1 = GameObject.Find("RollingCircle").GetComponent<CircleController>().goal1;
        goal2 = GameObject.Find("RollingCircle").GetComponent<CircleController>().goal2;

    }

    IEnumerator StartCountdown()
    {
        anim = countdownText.GetComponent<Animator>();
        yield return new WaitForSeconds(3f);
        for (int i = 5; i > -1; i--)
        {

            countdownText.text = i.ToString();
            countdownText.enabled = true;
            //anim.SetBool("play", true);
            anim.Play("Text_FadeOut");
            if (i == 1)
            {
                yield return new WaitForSeconds(0.8f);
                countdownText.enabled = false;
                break;
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
            
            //anim.SetBool("play", false);
 
        }

        GameObject.Find("StartScreen").SetActive(false);
        go.SetActive(true);
        //GameObject.Find("GoText").SetActive(true);
        yield return new WaitForSeconds(0.3f);
        // GameObject.Find("GoText").SetActive(false);
        go.SetActive(false);
    }


    public void PauseGame()
    {
        //maybe if touching the screen can be the trigger
        if (isGamePaused == false)
        {
            Stop();
        }
        else
        {
            Resume();
        }
        
    }

    public void Stop()
    {
        Debug.Log("stop");
        pauseButton.SetActive(false);
        //GameObject.Find("RollingCircle").SetActive(false);
        /*foreach (Rigidbody2D r in GameObject.FindObjectsOfType<Rigidbody2D>())
        {
            r.freezeRotation = true;
        }*/

        foreach (ShellMovement script in GameObject.FindObjectsOfType<ShellMovement>())
        {
            script.gameIsContinue = false;
        }
        GameObject.Find("RollingCircle").GetComponent<CircleController>().gameIsContinue = false;
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        isGamePaused = true;
    }
    public void Resume()
    {
        Debug.Log("resume");
        pauseButton.SetActive(true);
        //GameObject.Find("RollingCircle").SetActive(true);\
        foreach (ShellMovement script in GameObject.FindObjectsOfType<ShellMovement>())
        {
            script.gameIsContinue = true;
        }
        GameObject.Find("RollingCircle").GetComponent<CircleController>().gameIsContinue = true;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        isGamePaused = false;
    }



    public void CheckIfGameOver(int newNum,string player)
    {
        Debug.Log("enter decision");
        Debug.Log(newNum);
        Debug.Log(desireNum);

        


        if (newNum == desireNum)
        {
            if (player == "player1")
            {
                Debug.Log("oio");
                //GetNewDesireNum(desireNum);
                player1Point += 1;
                GameObject.Find("StarDistributor").GetComponent<GiveStar>().AwardStar("player1");
                
            }
            else
            {
                //GetNewDesireNum(desireNum);
                player2Point += 1;
                GameObject.Find("StarDistributor").GetComponent<GiveStar>().AwardStar("player2");
            }
            GameObject.Find("DesireNumber").GetComponent<TextMeshProUGUI>().text = "";
            desireNum = GameObject.Find("RollingCircle").GetComponent<CircleController>().ResetDesireNum(desireNum);
            
        }

        if (newNum == goal1 && player == "player1")
        {
            Debug.Log("player1 has achieved goal");
            player1Point += 1;
            GameObject.Find("StarDistributor").GetComponent<GiveStar>().AwardStar("player1");
            goal1 = GameObject.Find("RollingCircle").GetComponent<CircleController>().ResetGoal1(goal1);
        }
        
        if (newNum == goal2 && player == "player2")
        {
            player2Point += 1;
            GameObject.Find("StarDistrubutor").GetComponent<GiveStar>().AwardStar("player2");
            goal2 = GameObject.Find("RollingCircle").GetComponent<CircleController>().ResetGoal2(goal2);

        }

        if (player1Point == winningPoint || player2Point == winningPoint)
        {
            Debug.Log("the game has ended");

        }


    }
    private void GetNewDesireNum(int former_num)
    {
        //desireNum = GameObject.Find("RollingCircle").GetComponent<CircleController>().ResetDesireNum(former_num);
    }







}
