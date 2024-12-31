using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mov : MonoBehaviour
{
    public AudioClip jump_sound;
    public float movement_speed;
    private Rigidbody2D body;
    private Animator animator;
    public bool is_on_ground;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.localScale = new Vector3(2,2,1);
    }

    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal_input*movement_speed,body.velocity.y);

        if(horizontal_input > 0.01f)
        {
            transform.localScale = new Vector3(2,2,1);
        }
        else if (horizontal_input < -0.01f)
        {
            transform.localScale = new Vector3(-2,2,1);
        }

        if ( Input.GetKeyDown(KeyCode.Space) && is_on_ground==true)
        {
            Music.Use_for_all.Play_sound(jump_sound);
            Jump();
        }

        animator.SetBool("is_running",horizontal_input !=0);
        animator.SetBool("is_on_ground",is_on_ground==true);
    }
    
    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x,movement_speed);
        is_on_ground = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với đối tượng có tag "Ground"
    if (collision.gameObject.CompareTag("Ground"))
    {
        // Lấy thông tin va chạm
        ContactPoint2D contact = collision.contacts[0];
        if (contact.normal.y > 0.5f)
        {
            is_on_ground = true;
        }
        else if (Mathf.Abs(contact.normal.x) > 0.5f)
        {
            is_on_ground = true;
        }
        else
        {
            is_on_ground = false;
        }
    }
    }
}
