using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : MonoBehaviour
{
    public float speed = 7f;
    public float rangeAttack = 2.5f;
    Rigidbody2D rb;
    Boss boss;
    Transform player;
    Animator animator;
    BossHealth bossHealth;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = GetComponent<Rigidbody2D>();
       boss = GetComponent<Boss>();
       animator = GetComponent<Animator>();
       bossHealth = GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        boss.LookAtPlayer();
        float rangetoPlayer = Mathf.Abs(Vector2.Distance(player.position, rb.position));
            animator.SetBool("attack_v2", rangetoPlayer <= rangeAttack & bossHealth.health<=20f);
            
            animator.SetBool("attack", rangetoPlayer <= rangeAttack & bossHealth.health>20f);

    }
}
