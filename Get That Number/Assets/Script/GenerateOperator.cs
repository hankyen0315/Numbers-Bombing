using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOperator : MonoBehaviour
{






    [SerializeField]
    private List<Transform> pointSet = new List<Transform>();

    public GameObject mark;

    void Start()
    {
        StartCoroutine(GenerateMark());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator GenerateMark()
    {
        while (true)
        {
            
            float interval = Random.Range(0f, 2f);
            int point_index = Random.Range(0, 14);

            Transform point = pointSet[point_index];

            GameObject new_mark = Instantiate(mark, point);


            yield return new WaitForSeconds(interval);





        } 




    }







}
