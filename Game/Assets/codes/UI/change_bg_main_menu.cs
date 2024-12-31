using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_bg_main_menu : MonoBehaviour
{
    public Image menuImage;  // Image UI để thay đổi sprite

    // Các sprite tùy thuộc vào scene
    public Sprite defaultSprite;
    public Sprite scene1Sprite;
    public Sprite scene2Sprite;
    public Sprite scene3Sprite;

    void Start()
    {
        // Kiểm tra nếu có scene đã lưu
        if (PlayerPrefs.HasKey("LastScene"))
        {
            int sceneIndex = PlayerPrefs.GetInt("LastScene");

            // Thay đổi sprite dựa trên scene trước đó
            switch (sceneIndex)
            {
                case 1:
                    menuImage.sprite = scene1Sprite;
                    break;
                case 2:
                    menuImage.sprite = scene2Sprite;
                    break;
                case 3:
                    menuImage.sprite = scene3Sprite;
                    break;
                default:
                    menuImage.sprite = defaultSprite;
                    break;
            }
        }
        else
        {
            // Nếu không có scene đã lưu, sử dụng sprite mặc định
            menuImage.sprite = defaultSprite;
        }
    }
}
