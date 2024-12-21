using UnityEngine;
using System.Collections;

public class BossPatrol : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Transform boss;
    public float speed;
    private Vector3 initscale;
    public bool moving_left;
    public Animator animator;
    public Transform player;
    // Use this for initialization
    void Start()
    {
        initscale = boss.localScale;
    }

    void OnDisable()
    {
        animator.SetBool("moving", false);
    }
    void Update()
    {
        if (moving_left)
        {
            if (boss.position.x >= left.position.x)
                Moving(-1);
            else
                Change_direction();
        }
        else
        {
            if (boss.position.x <= right.position.x)
                Moving(1);
            else
                Change_direction();

        }

    }

    void Moving(int _direction_)
    {
        animator.SetBool("moving", true);
        boss.localScale = new Vector3(Mathf.Abs(initscale.x) * _direction_, initscale.y, initscale.z);
        boss.position = new Vector3(boss.position.x + Time.deltaTime * _direction_ * speed,
                                    boss.position.y, boss.position.z);
    }

    void Change_direction()
    {
        animator.SetBool("moving", false);
        moving_left = !moving_left;
    }
}
