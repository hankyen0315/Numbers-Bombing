using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveStar : MonoBehaviour
{

    public List<Transform> starPosition1;
    public List<Transform> starPosition2;

    public GameObject star;

    [SerializeField]
    private float speed;

    public GameObject newStar;



    /*private void Start()
    {
        newStar = Instantiate(star, gameObject.transform);
        StartCoroutine(MoveStarToPosition("player2"));
        star.GetComponent<Rigidbody2D>().MovePosition(starPosition1[0].position);
        starPosition1.Remove(starPosition1[0]);
    }*/
   

    public void AwardStar(string player)
    {    //GameObject newStar = Instantiate(star, gameObject.transform);
        StartCoroutine(MoveStarToPosition(player));
    }

    IEnumerator MoveStarToPosition(string player)
    {
        GameObject newStar = Instantiate(star, gameObject.transform);
        if (player == "player1")
        {
            Debug.Log("giving the fucking star to player 1");
            newStar.GetComponent<Animator>().Play("star_shining_appearing");
            yield return new WaitForSeconds(1.25f);
            while (newStar.transform.position != starPosition1[0].position)
            {
                newStar.transform.position = Vector3.MoveTowards(newStar.transform.position, starPosition1[0].position, speed*Time.deltaTime);
                Debug.Log("moving...");
                yield return new WaitForSeconds(0.01f);
            }
            Debug.Log("reach");
            starPosition1.Remove(starPosition1[0]);
            
        }

        else if (player == "player2")
        {
            newStar.transform.rotation = new Quaternion(0f, 0f, 180f,0f);
            newStar.GetComponent<Animator>().Play("star_shining_appearing");
            yield return new WaitForSeconds(1.25f);
            while (newStar.transform.position != starPosition2[0].position)
            {
                newStar.transform.position = Vector3.MoveTowards(newStar.transform.position, starPosition2[0].position, speed * Time.deltaTime);
                Debug.Log("moving...");
                yield return new WaitForSeconds(0.01f);
            }
            starPosition1.Remove(starPosition2[0]);
            
        }
        //don't need to call it here
        //GameObject.Find("RollingCircle").GetComponent<CircleController>().ResetDesireNum(former_num);

    }










}
