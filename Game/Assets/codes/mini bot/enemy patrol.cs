using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Transform enemy;
    public float speed;
    private Vector3 initscale;
    public bool moving_left;
    public Animator animator;
    

    void Start()
    {
        initscale = enemy.localScale;
        //animator = GetComponent<Animator>();
    }

    void OnDisable()
    {
        animator.SetBool("moving",false);
    }
    void Update()
    {
        if(moving_left)
        {
            if(enemy.position.x >=left.position.x)
                Moving(-1);
            else
                Change_direction();
        }
        else
        {
            if(enemy.position.x <= right.position.x)
                Moving(1);
            else
                Change_direction();

        }

    }
    
    void Moving(int _direction_)
    {
        animator.SetBool("moving",true);
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * _direction_,initscale.y,initscale.z);
        enemy.position = new Vector3(enemy.position.x+ Time.deltaTime * _direction_ * speed,
                                    enemy.position.y,enemy.position.z);
    }

    void Change_direction()
    {
        animator.SetBool("moving",false);
        moving_left = !moving_left;
    }
}
