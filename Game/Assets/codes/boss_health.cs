using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float maxHealth = 40f;
    public float health = 20f;
    // Start is called before the first frame update
    public void takeDam(float dame)
    {
        health -= dame;

    }
}
