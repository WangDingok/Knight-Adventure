using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject game_over_screen;
    public AudioClip game_over_sound;

    public GameObject pause_screen;
    public GameObject start_menu;
    void Start()
    {
        game_over_screen.SetActive(false);
        pause_screen.SetActive(false);
        start_menu.SetActive(true);
    }
    public void Game_over()
    {
        game_over_screen.SetActive(true);
        Music.Use_for_all.Play_sound(game_over_sound);

    }

    public void start_game()
    {
       SceneManager.LoadScene(1);
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void main_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause_screen.activeInHierarchy)
                Pause(false);
            else
                Pause(true);
        }
    }

    public void Pause(bool status)
    {
        pause_screen.SetActive(status);

        if(status)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}
