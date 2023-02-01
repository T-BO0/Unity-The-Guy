using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] GameObject[] checkPoints;
    [SerializeField] float speed = 2f;
    int checkPointIndex = 0;


    void Update()
    {
        //check distance between two points less than 0.1, switch checkPoint
        if(Vector2.Distance(checkPoints[checkPointIndex].transform.position,transform.position) < .1f)
        {
            checkPointIndex++;
            if(checkPointIndex >= checkPoints.Length)
            {
                checkPointIndex = 0;
            }
        }
        //move towards checkPoint
        transform.position = Vector2.MoveTowards(transform.position, checkPoints[checkPointIndex].transform.position, Time.deltaTime*speed);
    }
}
