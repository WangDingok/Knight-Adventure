using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class enemy_projecttile : enemy_damage
{
    public float speed;
    public float reset_time;
    private float life_time;
    private Animator animator;
    public bool hit;
    private BoxCollider2D collider2d;


    void Start()
    {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
    {
        hit = false;
        life_time = 0;
        gameObject.SetActive(true);
        collider2d.enabled = true;
    }


    void Update()
    {
        if (hit==true)
            return;
        float movement_speed = speed * Time.deltaTime;
        transform.Translate(movement_speed,0,0);

        life_time += Time.deltaTime;
        if (life_time > reset_time)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);
        collider2d.enabled = false;
        if(animator!=null)
        {
            animator.SetTrigger("explore");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void DeActivate()
    {
        gameObject.SetActive(false);
    }
}
