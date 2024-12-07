using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform main_cam;
    public Transform mid_bg;
    public Transform side_bg;
    public float len;
    
    void Update()
    {
        if(main_cam.position.x>mid_bg.position.x)
        {
            update_bg_pos(Vector3.right);
        }
        else if (main_cam.position.x<mid_bg.position.x)
        {
            update_bg_pos(Vector3.left);
        }
    }

    void update_bg_pos(Vector3 direction)
    {
        side_bg.position = side_bg.position + direction * len;
        Transform x = mid_bg;
        mid_bg = side_bg;
        side_bg = x;
    }
}
