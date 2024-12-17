using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_fire_holder : MonoBehaviour
{
    public Transform enemy;

    void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
