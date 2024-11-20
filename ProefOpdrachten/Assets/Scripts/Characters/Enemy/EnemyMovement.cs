using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private int patrolDestination;

    
    [SerializeField] private bool isChasing;

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }

    private void EnemyPatrol()
    {
        switch (isChasing)
        {
            case true:
                if(transform.position.x > playerTransform.position.x)
                {
                    transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
                }
                if (transform.position.x < playerTransform.position.x)
                {
                    transform.position += Vector3.right * (moveSpeed * Time.deltaTime);
                }
                break;
            case false:
                if(Vector2.Distance(transform.position, playerTransform.position)< chaseDistance)
                {
                    isChasing = true;
                }
                
                if (patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[0].position) < 2f)
                    {
                        patrolDestination = 1;
                    }
                }

                if (patrolDestination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[1].position) < 2f)
                    {
                        patrolDestination = 0;
                    }
                }
                break;
        }
    }
}