using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fire_trap : MonoBehaviour
{
    public AudioClip fire_trap_sound;
    public float damage;                 
    public float cooldown_activation;    
    public float time_activate;          
    private Animator animator;
    private SpriteRenderer sprite_renderer;
    private bool triggerer;
    private bool activate;
    private heath player_health;  
    private float damageTimer;        

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
            player_health = collision.GetComponent<heath>();
            if (player_health != null && !triggerer)
            {
                StartCoroutine(Activation_trap());
                Music.Use_for_all.Play_sound(fire_trap_sound);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player_health = null;
        }
    }
 
    private void Update()
    {
        if (activate && player_health != null)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= 0.1f) 
            {
                player_health.Take_damage(damage * 0.2f); 
                damageTimer = 0f;
            }
        }
    }

    IEnumerator Activation_trap()
    {
        triggerer = true;
        sprite_renderer.color = Color.red; 
        yield return new WaitForSeconds(cooldown_activation); 

        activate = true;
        animator.SetBool("activated", true);

        yield return new WaitForSeconds(time_activate);
        activate = false;
        triggerer = false;
        animator.SetBool("activated", false);
        sprite_renderer.color = Color.white; 
    }
}
