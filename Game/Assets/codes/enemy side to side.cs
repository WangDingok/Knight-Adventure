 
using UnityEngine;

public class enemysidetoside : MonoBehaviour
{
    public float speed;
    public float move_distance;
    public float dam;

    private bool move_left;
    private float left_edge;
    private float right_edge;

    // Start is called before the first frame update
    void Start()
    {
        left_edge = transform.position.x - move_distance;
        right_edge = transform.position.x + move_distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(move_left)
        {
            if(transform.position.x > left_edge)
            {
                transform.position = new Vector3(transform.position.x - speed*Time.deltaTime,transform.position.y,transform.position.z );
            }
            else
            {
                move_left = false;        
            }
        }
        else
        {
            if(transform.position.x < right_edge)
            {
                transform.position = new Vector3(transform.position.x + speed*Time.deltaTime,transform.position.y,transform.position.z );    
            }
            else
            {
               move_left = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<heath>().take_damage(dam); 
        } 
    }
}
