using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class selectionarrow : MonoBehaviour
{
    public RectTransform[] optional;
    public AudioClip change_sound;
    public AudioClip enter_sound;
    RectTransform rect;

    int curent_pos;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Change_pos(-1);
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Change_pos(1);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Enter_Option();
        }
    }

    void Enter_Option()
    {
        Music.Use_for_all.Play_sound(enter_sound);


        optional[curent_pos].GetComponent<Button>().onClick.Invoke();
    }

    void Change_pos(int change)
    {
        curent_pos += change;

        if(change !=0)
        {
            Music.Use_for_all.Play_sound(change_sound);
        }
        if(curent_pos<0)
        {
            curent_pos = optional.Length - 1;
        }
        else if (curent_pos > optional.Length - 1)
        {
            curent_pos = 0;
        }

        rect.position = new Vector3(rect.position.x,optional[curent_pos].position.y,0);

    }
}
