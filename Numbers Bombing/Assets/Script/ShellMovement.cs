using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Button button;


    public float rotateSpeed = 20f;

    public GameObject explosion;
    public GameObject text;

    public bool gameIsContinue=true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsContinue)
        {
            gameObject.transform.Rotate(0f, 0f, rotateSpeed);
        }
        





    }

    public void DestroyExplosion()
    {

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        text.SetActive(false);
        explosion.SetActive(true);
        explosion.GetComponentInChildren<Animator>().Play("Explosion");
        Destroy(gameObject,0.99f);
    }


}
