using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.Collections;

public class PlayerDetails : MonoBehaviour
{
    //GameObject called is the player
   
    public Animator animator;

    //Transform of player and of the edges in tthe area

    public Collider edgeCollide;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(edgeCollide.isTrigger)
        {
            animator.SetBool("OnEdge",true);
            //if player gets near the edge the animation will trigger
        }
    }
}
