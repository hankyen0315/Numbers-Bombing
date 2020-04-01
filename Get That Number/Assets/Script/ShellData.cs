using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShellData : MonoBehaviour
{

    public int numberTextValue;

    private int oper_order;
    public string oper;
    public List<Sprite> operIconList;

    private SpriteRenderer spRenderer;

    private TextMeshPro shellNumText;




    // Start is called before the first frame update
    void Start()
    {
        spRenderer = gameObject.GetComponent<SpriteRenderer>();

        numberTextValue = Random.Range(0, 10);

        if (numberTextValue == 0)
        {
            oper_order = 2;
        }
        else if (numberTextValue == 1)//乘一和除一都不需要
        {
            oper_order = Random.Range(0, 2);
        }
        else
        {
            oper_order = Random.Range(0, 4);
        }

        if (gameObject.tag == "AOEshell")
        {
            oper_order = Random.Range(0, 3);
        }
        
        switch (oper_order)
        {
            case 0:
                oper = "+";
                spRenderer.sprite = operIconList[0];
                break;
            case 1:
                oper = "-";
                spRenderer.sprite = operIconList[1];
                break;
            case 2:
                oper = "x";
                spRenderer.sprite = operIconList[2];
                break;
            case 3:
                oper = "÷";
                spRenderer.sprite = operIconList[3];
                break;
        }//get the random operator and value

        shellNumText = gameObject.GetComponentInChildren<TextMeshPro>();
        shellNumText.text = numberTextValue.ToString();
    }

}
