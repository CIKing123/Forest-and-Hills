using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] private Transform movePosition;

    [SerializeField] private Vector3 targetRadius;

    public NavMeshAgent agent;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        agent.destination = movePosition.position;
        animator.SetFloat("speed", 3);
        //if enemy AI moves move the speed will be more than zero
        if (agent.destination == movePosition.position)
        {
            agent.destination = movePosition.position;
        }
        else if(transform.position == movePosition.position)
        { 
            agent.destination = movePosition.position;
        }
        
    }
}
