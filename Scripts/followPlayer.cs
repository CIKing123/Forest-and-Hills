using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    public float targetSpeed =0.123f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition,targetSpeed);
        transform.position = smoothPosition;
    }
}
