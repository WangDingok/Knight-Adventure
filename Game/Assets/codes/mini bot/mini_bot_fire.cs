using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_bot_fire : MonoBehaviour
{

    public AudioClip casting_sound;
    public Transform player;
    public float attack_cooldown;
    public float dam;
    public BoxCollider2D box_collider;
    public float collider_distance;
    private float cooldown_time = Mathf.Infinity;
    public float range;
    //private heath player_heath;

    public LayerMask player_layer;
    private Animator animator;
    private enemypatrol patrol;

    public Transform fire_point;
    public GameObject[] fire_index;

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
                cooldown_time = 0;
                animator.SetTrigger("range_attack");
            }
        }

        if (player.position.x > transform.position.x && transform.localScale.x < 0)
        {
            Flip();
        }
    else if (player.position.x < transform.position.x && transform.localScale.x > 0)
        {
            Flip();
        }

        if(patrol!=null)
        {
            patrol.enabled = !Seeplayer();
        }
        
    }
    void Flip()
{
    Vector3 currentScale = transform.localScale;
    currentScale.x = -currentScale.x;
    transform.localScale = currentScale;
}

    private bool Seeplayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box_collider.bounds.center + transform.right*range*transform.localScale.x * collider_distance,
        new Vector3(box_collider.bounds.size.x*range,box_collider.bounds.size.y,box_collider.bounds.size.z),
        0,Vector2.left, 0, player_layer);
    
        if (hit.collider !=null)
            return true;
        else
            return false;
    }

    void Range_attack()
    {
        Music.Use_for_all.Play_sound(casting_sound);
        cooldown_time = 0;
        fire_index[Find_index_fire()].transform.position = fire_point.position;
        fire_index[Find_index_fire()].GetComponent<enemy_projecttile>().ActivateProjectile();
    }

    int Find_index_fire()
    {
        for(int i=0;i<fire_index.Length;i++)
        {
            if(!fire_index[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box_collider.bounds.center + transform.right *range*transform.localScale.x * collider_distance, 
        new Vector3(box_collider.bounds.size.x*range,box_collider.bounds.size.y,box_collider.bounds.size.z));
    }

}
