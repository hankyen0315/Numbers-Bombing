using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkBehaviour : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> operators = new List<Sprite>();

    private SpriteRenderer sprite;
    public Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int operator_num = Random.Range(0, 8);
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = operators[operator_num];

        anim.Play("Mark_Fade_IN_AND_OUT");

    }

    public void DestroyMyself()
    {
        Destroy(this.gameObject);
        
    }
}
