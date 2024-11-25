 
using UnityEngine;

public class heath_item_collect : MonoBehaviour
{
    public float heath_value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<heath>().add_heath(heath_value);
            gameObject.SetActive(false);
        }
    }
}
