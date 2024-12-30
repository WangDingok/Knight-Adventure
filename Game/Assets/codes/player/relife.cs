using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relife : MonoBehaviour
{
    public AudioClip re_life_sound;
    Transform checkpoint_pos;
    heath player_heath;

    UImanager ui_manager;


    void Start()
    {
        player_heath = GetComponent<heath>();
        ui_manager = FindObjectOfType<UImanager>();
    }

    public void check_re_life()
    {
        if(checkpoint_pos==null)
        {
            ui_manager.Game_over();
            return;
        }
        transform.position = checkpoint_pos.position;
        player_heath.Re_life();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.tag=="checkpoint")
        {
            checkpoint_pos = collider.transform;
            Music.Use_for_all.Play_sound(re_life_sound);
            collider.GetComponent<Collider2D>().enabled = false;
        }
    }
}
