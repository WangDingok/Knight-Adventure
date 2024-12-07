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
    public void ActivateProjectile()
    {
        life_time = 0;
        gameObject.SetActive(true);
    }

    void Update()
    {
        float movement_speed = speed * Time.deltaTime;
        transform.Translate(movement_speed,0,0);

        life_time += Time.deltaTime;
        if (life_time > reset_time)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);
    }
}
