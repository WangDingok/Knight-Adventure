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
    public GameObject menu_level;
    public heath boss_heath;

    bool win;
    void Start()
    {
        game_over_screen.SetActive(false);
        pause_screen.SetActive(false);
        start_menu.SetActive(true);
        menu_level.SetActive(false);
        boss_heath = GetComponent<heath>();
    }

    public void Game_over()
    {
        game_over_screen.SetActive(true);
        Music.Use_for_all.Play_sound(game_over_sound);
    }

    public void load_map_1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void load_map_2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void load_map_3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void start_game()
    {
       //Time.timeScale = 1;
       //SceneManager.LoadScene(1);
       menu_level.SetActive(true);
       start_menu.SetActive(false);
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void back_menu()
    {
        menu_level.SetActive(false);
       start_menu.SetActive(true);
    }

    public void main_menu()
    {
        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
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

        if(boss_heath!= null&&win!=true&&boss_heath.current_heath <= 0)
        {
            SceneManager.LoadScene(4);
            win = true;
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
