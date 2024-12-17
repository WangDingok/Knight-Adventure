 
using UnityEngine;

public class heath_item_collect : MonoBehaviour
{
    public AudioClip add_heath_sound;
    public float heath_value;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Music.Use_for_all.Play_sound(add_heath_sound);
            collision.GetComponent<heath>().Add_heath(heath_value);
            gameObject.SetActive(false);
        }
    }
}
