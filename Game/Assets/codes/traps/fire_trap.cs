using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fire_trap : MonoBehaviour
{
    public float damage;                // Sát thương mỗi lần
    public float cooldown_activation;   // Thời gian giữa mỗi lần gây sát thương
    public float time_activate;         // Thời gian bẫy hoạt động
    private Animator animator;
    private SpriteRenderer sprite_renderer;
    private bool triggerer;
    private bool activate;
    private heath player_health;  
    private float damageTimer;        // Cách viết đúng "Health" thay vì "heath"

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        damageTimer = 0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Khi người chơi vào bẫy, lấy thông tin sức khỏe
            player_health = collision.GetComponent<heath>();
            if (player_health != null && !triggerer)
            {
                StartCoroutine(Activation_trap());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player_health = null; // Gỡ sức khỏe khi người chơi ra khỏi bẫy
        }
    }
 
    private void Update()
    {
        if (activate && player_health != null)
        {
            // Tính toán thời gian và gây sát thương mỗi giây
            damageTimer += Time.deltaTime;

            // Chỉ gây sát thương mỗi lần tính đủ thời gian (ví dụ mỗi 0.1 giây)
            if (damageTimer >= 0.1f) 
            {
                player_health.take_damage(damage * 0.2f); // Chia nhỏ sát thương theo thời gian
                damageTimer = 0f; // Reset timer sau mỗi lần gây sát thương
            }
        }
    }

    IEnumerator Activation_trap()
    {
        triggerer = true;
        sprite_renderer.color = Color.red; // Đổi màu bẫy khi kích hoạt
        yield return new WaitForSeconds(cooldown_activation); // Đợi cooldown trước khi gây sát thương

        // Kích hoạt bẫy
        activate = true;
        animator.SetBool("activated", true);

        // Tiến hành thiệt hại theo thời gian
        yield return new WaitForSeconds(time_activate);

        // Dừng thiệt hại và tắt bẫy
        activate = false;
        triggerer = false;
        animator.SetBool("activated", false);
        sprite_renderer.color = Color.white; // Khôi phục lại màu sắc của bẫy
    }
}
