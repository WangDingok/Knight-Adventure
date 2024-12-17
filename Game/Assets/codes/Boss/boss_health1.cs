using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float maxHealth = 40f;
    public float health = 20f;
    Animator animator;

    void start(){
       animator = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    public void takeDam(float dame)
    {
        health -= dame;
        if(health > 0)
       {
            animator.SetTrigger("hurt");
       }
       else
       {
            animator.SetTrigger("die");
            GetComponent<Boss_run>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
       }
    }
}
