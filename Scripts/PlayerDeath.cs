using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //GameController
    public GameController gameController;

    public float restartDelay = 2f;
    
    //Player position
    public Transform player;

    //Collider for enemy
    public Collider enemyCollider;

    public float PlayerHealth = 1f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OutOfBounds()
    {
        if (player.position.y <= -13)
        {
            Debug.Log("Restart");
            //Invoke allows a method to be called over a specific time
            gameController.Invoke("Restart", restartDelay);
        }
    }

    void GainHealth()
    {
        PlayerHealth = 1f;
    }
    void Die()
    {
        if(PlayerHealth == 0)
        {
            animator.SetBool("isDying", true);
            gameController.Invoke("Restart",restartDelay);
        }
    }

    void TakeDamage()
    {
        if (enemyCollider.isTrigger)
        {
            PlayerHealth = 0;
        }
        else
        {
            PlayerHealth = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth = 1f;
        OutOfBounds();
        Die();
    }

    private void LateUpdate()
    {

    }
}
