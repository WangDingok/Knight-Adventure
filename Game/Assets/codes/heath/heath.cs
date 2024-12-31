using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;
using UnityEngine;

public class heath : MonoBehaviour
{
    public AudioClip die_sound;
    public AudioClip hurt_sound;
    public float initial_heath;
    public float current_heath {get; private set; }
    private Animator animator;
    public Behaviour[] components;
    public Transform player_pos;

    [Header("when hurt")]
    public float invulnerable_time;
    bool die;
    private SpriteRenderer sprite_render;
    // Start is called before the first frame update
    void Start()
    {
          current_heath = initial_heath;
          animator = GetComponent<Animator>();
          sprite_render = GetComponent<SpriteRenderer>();
          player_pos = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_pos.position.y < -30f&&die!=true)
    {
        Take_damage(current_heath);  
    }
    }

    public void Take_damage(float _damage_)
    {
        if (die) return;
        current_heath = Mathf.Clamp(current_heath - _damage_ , 0 , initial_heath); 
       if(current_heath > 0)
       {
            animator.SetTrigger("hurt");
            StartCoroutine(Invulnerable());
            Music.Use_for_all.Play_sound(hurt_sound);
       }
       else
       {
            die = true; 
            foreach(Behaviour component in components)
            {
                component.enabled = false;
            }
            animator.SetBool("is_on_ground",true);
            animator.SetTrigger("die");
            Music.Use_for_all.Play_sound(die_sound);
       }

    }
    

    public void Add_heath(float _value_)
    {
        current_heath = Mathf.Clamp(current_heath + _value_ , 0 , initial_heath);
    }

    public void Re_life()
    {
        Add_heath(initial_heath);
        animator.ResetTrigger("die");
        animator.Play("IDLE");
        StartCoroutine(Invulnerable());

        foreach(Behaviour component in components)
        {
            component.enabled = true;
        }
        die = false;
    }

    IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(10,11 , true); 
        for(int i=0 ; i< invulnerable_time; i++)
        {
            sprite_render.color = new Color(1,0,0 , 0.7f);
            yield return new WaitForSeconds(0.1f);
            sprite_render.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        Physics2D.IgnoreLayerCollision(10,11 , false); 
    }

    void DeActivate()
    {
        gameObject.SetActive(false);
    }
}
