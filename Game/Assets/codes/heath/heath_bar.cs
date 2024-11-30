using UnityEngine.UI; 
using UnityEngine;

public class heath_bar : MonoBehaviour
{
    public heath player_heath;
    public Image total_heathbar;
    public Image current_heathbar;
    // Start is called before the first frame update
    void Start()
    {
        total_heathbar.fillAmount = player_heath.current_heath / 10;
    }

    // Update is called once per frame
    void Update()
    {
        current_heathbar.fillAmount = player_heath.current_heath / 10;
    }
}
