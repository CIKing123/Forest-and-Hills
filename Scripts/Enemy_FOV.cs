using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FOV : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject PlayerTarget;

    public LayerMask targetMask;

    public LayerMask obstructionMask;

    public bool canSeePlayer;


    private void Start()
    {
       PlayerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        while(true)
        {
            yield return wait;
            FOVCheck();
        }

    }

    void FOVCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            //Overlap Shpere returns array
            Vector3 directionTarget = (target.position - transform.position).normalized;

            //Angle Check
            if(Vector3.Angle(transform.position, directionTarget)< angle/2)
            {
                float distanceToTarget = Vector3.Distance(transform.position,target.position);
                if (!Physics.Raycast(transform.position, directionTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else 
                    canSeePlayer = false;
            }
            else 
            {
                canSeePlayer = false;
            }
        }
    }
}

