using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float cooldown;
    public Transform fire_point;
    public GameObject[] fire_index;
    private float cooldown_time;

    void Attack()
    {
        cooldown_time = 0;

        fire_index[Find_fire()].transform.position = fire_point.position;
        fire_index[Find_fire()].GetComponent<enemy_projecttile>().ActivateProjectile();
    }

    int Find_fire()
    {
        for (int i=0;i< fire_index.Length; i++)
        {
            if(!fire_index[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    void Update()
    {
        cooldown_time += Time.deltaTime;
        if(cooldown_time >= cooldown)
            Attack();
    }
}
