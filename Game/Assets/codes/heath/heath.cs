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

    [Header("when hurt")]
    public float invulnerable_time;
    private SpriteRenderer sprite_render;
    // Start is called before the first frame update
    void Start()
    {
          current_heath = initial_heath;
          animator = GetComponent<Animator>();
          sprite_render = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void Take_damage(float _damage_)
    {
        current_heath = Mathf.Clamp(current_heath - _damage_ , 0 , initial_heath); 
       if(current_heath > 0)
       {
            animator.SetTrigger("hurt");
            StartCoroutine(Invulnerable());
            Music.Use_for_all.Play_sound(hurt_sound);
       }
       else
       {
            animator.SetTrigger("die");
            foreach(Behaviour component in components)
            {
                component.enabled = false;
            }
            Music.Use_for_all.Play_sound(die_sound);
       }
    }
    

    public void Add_heath(float _value_)
    {
        current_heath = Mathf.Clamp(current_heath + _value_ , 0 , initial_heath);
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
