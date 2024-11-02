using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPointTransforms;
    public float enemyPatrolSpeed;
    public int patrolPoint;

    public HealthManager healthManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (patrolPoint == 0)
        {
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, patrolPointTransforms[0].position, enemyPatrolSpeed * Time.deltaTime);
            if(UnityEngine.Vector2.Distance(transform.position, patrolPointTransforms[0].position) < 0.5f)
            {
                transform.localScale = new UnityEngine.Vector3(-.2f, .2f, .2f);
                patrolPoint = 1;
            }
        }

        if (patrolPoint == 1)
        {
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, patrolPointTransforms[1].position, enemyPatrolSpeed * Time.deltaTime);
            if (UnityEngine.Vector2.Distance(transform.position, patrolPointTransforms[1].position) < 0.5f)
            {
                transform.localScale = new UnityEngine.Vector3(.2f, .2f, .2f);
                patrolPoint = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerController>())
        {
           Debug.Log("Ellen died!!");
           healthManager.health--;
        }
    }
}
