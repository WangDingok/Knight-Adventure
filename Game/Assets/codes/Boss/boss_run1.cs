using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : MonoBehaviour
{
    public float speed = 7f;
    public float rangeAttack;
    public float range_see_player;
    Rigidbody2D rb;
    Boss boss;
    Transform player;
    Animator animator;
    heath bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        boss = GetComponent<Boss>();
        animator = GetComponent<Animator>();
        bossHealth = GetComponent<heath>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        float rangetoPlayer = Mathf.Abs(Vector2.Distance(player.position, rb.position));

        if (rangetoPlayer < range_see_player)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        animator.SetBool("walk", rangetoPlayer < range_see_player);

        boss.LookAtPlayer();
        //float rangetoPlayer = Mathf.Abs(Vector2.Distance(player.position, rb.position));
        animator.SetBool("attack_v2", rangetoPlayer <= rangeAttack & bossHealth.current_heath <= 20f);

        animator.SetBool("attack", rangetoPlayer <= rangeAttack & bossHealth.current_heath > 20f);

    }
}
