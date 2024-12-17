using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSword : MonoBehaviour
{
    public AudioClip sword_sound;
    public Vector3 attackOffset;
    public float attackRange = 2f;
    public LayerMask attackMask;
    [SerializeField] private float normalDamage = 0.5f;
    [SerializeField] private float enragedDamage = 1f;
    heath playerHealth;

    public void Attack()
    {
        PerformAttack(normalDamage);
    }

    public void EnragedAttack()
    {
        PerformAttack(enragedDamage);
    }

    private void PerformAttack(float damage)
    {
        Vector3 pos = transform.position + transform.right * attackOffset.x + transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            playerHealth = colInfo.GetComponent<heath>();
            if (playerHealth != null)
            {
                //debug
                Music.Use_for_all.Play_sound(sword_sound);
                playerHealth.Take_damage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position + transform.right * attackOffset.x + transform.up * attackOffset.y;
        Gizmos.DrawWireSphere(pos, attackRange);
    }
}