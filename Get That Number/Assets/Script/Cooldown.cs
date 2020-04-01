using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooldown : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI timerText;

    private bool canCount;
    private float remainTime=0.1f;

    private bool ifStartNow;



    private void Update()
    {
        if (canCount)
        {
            

            if (ifStartNow)
            {
                iconImage.color = new Color(0.7f, 0.7f, 0.7f);
                //Debug.Log("Start timer");
            }
            

            timerText.enabled = true;

            
            remainTime -= Time.deltaTime;
            timerText.text = remainTime.ToString("0.00");
            iconImage.color += new Color(1f, 1f, 1f) * ((Time.deltaTime / remainTime )* (0.1f));
            //Debug.Log("counting...");
            gameObject.GetComponent<Button>().enabled = false;
            ifStartNow = false;

        }

        if (remainTime <= 0f)
        {
            canCount = false;
            timerText.enabled = false;
            iconImage.color = new Color(1f, 1f, 1f);
            gameObject.GetComponent<Button>().enabled = true;
        }
    }





    public void CoolDownAfterBeingClick(int time=0)
    {
        canCount = true;
        ifStartNow = true;
        remainTime = 3+time;


    }





}
