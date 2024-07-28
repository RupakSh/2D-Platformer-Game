using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPointTransforms;
    public float enemyPatrolSpeed;
    public int patrolPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (patrolPoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPointTransforms[0].position, enemyPatrolSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPointTransforms[0].position) < 0.1f)
            {
                patrolPoint = 1;
            }
        }

        if (patrolPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPointTransforms[1].position, enemyPatrolSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPointTransforms[1].position) < 0.1f)
            {
                patrolPoint = 0;
            }
        }
    }
}
