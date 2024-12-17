using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public AudioClip casting_sound;
    public float dam;

    public BoxCollider2D box_collider;
    public float range;
    private heath enemy_heath;

    public LayerMask enemy;
    public float collider_distance;
    public float cooldown_attack;
    public float cooldown_attack_sword;
    public Transform bullet_point;
    public GameObject[] bullet_index;
    private Animator animator; 
    private player_mov player_movement;
    private float cooldown_time = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_movement = GetComponent<player_mov>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown_time > cooldown_attack)
        {
            Attack_Shooting(); 
        }

        if (Input.GetKey(KeyCode.J) && cooldown_time > cooldown_attack_sword)
        {
            Attack();
        }

        cooldown_time += Time.deltaTime;
        
    }

    void Attack_Shooting()
    {
        Music.Use_for_all.Play_sound(casting_sound);
        animator.SetTrigger("shooting");
        cooldown_time = 0;

        // object pooling
        bullet_index[find_bullet_index()].transform.position = bullet_point.position;
        
        bullet_index[find_bullet_index()].GetComponent<bullet>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    void Attack()
    {
        animator.SetTrigger("attack");
        cooldown_time = 0;
    }

    private bool SeeEnemy()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box_collider.bounds.center + transform.right*range*transform.localScale.x * collider_distance,
        new Vector3(box_collider.bounds.size.x*range,box_collider.bounds.size.y,box_collider.bounds.size.z),
        0,Vector2.left, 0, enemy);
    
        if (hit.collider !=null)
        {
            enemy_heath = hit.transform.GetComponent<heath>();
            return true;
        }
        else
            return false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box_collider.bounds.center + transform.right *range*transform.localScale.x * collider_distance, 
        new Vector3(box_collider.bounds.size.x*range,box_collider.bounds.size.y,box_collider.bounds.size.z));
    }

    void dam_player()
    {
        if(SeeEnemy())
        {
            enemy_heath.Take_damage(dam);
        }
    }

    int find_bullet_index()
    {
        for(int i=0;i<bullet_index.Length ; i++)
        {
            if(!bullet_index[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
