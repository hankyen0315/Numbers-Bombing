using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToItsPosition : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 startPosition;

    public float desireDistance;



    [SerializeField]
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        float moveDistance = Vector3.Distance(currentPosition, startPosition);
        if (moveDistance <= desireDistance)
        {
            rb.velocity = transform.up * speed;

        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

    }





}
