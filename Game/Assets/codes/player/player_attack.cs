using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{

    public float cooldown_attack;
    public Transform bullet_point;
    public GameObject[] bullet_index;
    private Animator animator; 
    private player_mov player_movement;
    private float cooldown_time = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_movement = GetComponent<player_mov>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown_time > cooldown_attack)
        {
            Attack_Shooting(); 
        }

        cooldown_time += Time.deltaTime;
        
    }

    void Attack_Shooting()
    {
        animator.SetTrigger("shooting");
        cooldown_time = 0;

        // object pooling
        bullet_index[find_bullet_index()].transform.position = bullet_point.position;
        
        bullet_index[find_bullet_index()].GetComponent<bullet>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    int find_bullet_index()
    {
        for(int i=0;i<bullet_index.Length ; i++)
        {
            if(!bullet_index[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
