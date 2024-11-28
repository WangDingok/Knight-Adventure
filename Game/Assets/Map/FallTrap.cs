using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daRoi = false;
    public Transform diemKhoiPhuc;
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("")&&!daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("KhoiPhuc", 2f);
        }
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag(""))
        {
            SceneManager.LoadScene("Map1");
        }
    }
    private void KhoiPhuc()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = diemKhoiPhuc.position;
        daRoi = false;
    }
}
