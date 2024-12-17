using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_bot : MonoBehaviour
{
    public AudioClip fight_sound;
    
    public float attack_cooldown;
    public float dam;
    public BoxCollider2D box_collider;
    public float collider_distance;
    private float cooldown_time = Mathf.Infinity;
    public float range;

    private enemypatrol patrol;
    private heath player_heath;

    public LayerMask player_layer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        patrol = GetComponentInParent<enemypatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown_time += Time.deltaTime;
        if(Seeplayer())
        {
            if (cooldown_time >= attack_cooldown)
            {
                Music.Use_for_all.Play_sound(fight_sound);
                cooldown_time = 0;
                animator.SetTrigger("attack");
            }
        }

        if(patrol!=null)
        {
            patrol.enabled = !Seeplayer();
        }
        
    }

    private bool Seeplayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box_collider.bounds.center + transform.right*range*transform.localScale.x * collider_distance,
        new Vector3(box_collider.bounds.size.x*range,box_collider.bounds.size.y,box_collider.bounds.size.z),
        0,Vector2.left, 0, player_layer);
    
        if (hit.collider !=null)
        {
            player_heath = hit.transform.GetComponent<heath>();
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
        if(Seeplayer())
        {
            player_heath.Take_damage(dam);
        }
    }
}
