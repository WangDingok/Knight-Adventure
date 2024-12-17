using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class spike_head : enemy_damage
{
    public AudioClip spike_head_sound;
    public LayerMask player_layer;
    public float speed;
    public float range;
    public float delay;
    private Vector3 moving;
    private Vector3[] moving_direction = new Vector3[4];
    private float check_time;
    private bool attack;

    void OnEnable()
    {
        stop();
    }
    void Update()
    {
        if(attack==true)
            transform.Translate(moving * Time.deltaTime * speed);
        else
        {
            check_time += Time.deltaTime;
            if (check_time > delay)
                Check_Player();
        }
    }

    void Check_Player()
    {
        direction();
        for(int i=0 ;i< moving_direction.Length; i++)
        {
            //Debug.DrawRay(transform.position,moving_direction[i],Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position , moving_direction[i] , range/2 , player_layer);

            if (hit.collider !=null && !attack)
            {
                attack = true;
                moving = moving_direction[i];
                check_time = 0;
            }
        }
    }

    void direction()
    {
        moving_direction[0] = transform.right * range;
        moving_direction[1] = -transform.right * range;
        moving_direction[2] = transform.up * range;
        moving_direction[3] = -transform.up * range;

    }

    void stop()
    {
        moving = transform.position;
        attack = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Music.Use_for_all.Play_sound(spike_head_sound);
        base.OnTriggerEnter2D(collision);
        stop();
    }
}
