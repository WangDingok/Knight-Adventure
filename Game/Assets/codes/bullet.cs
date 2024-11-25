 
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bullet_speed ;
    public bool hit;

    private float direction;
    private Animator animator;
    private BoxCollider2D box_collider;
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        box_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
            return;
        float movement_speed = bullet_speed*Time.deltaTime*direction;
        transform.Translate(movement_speed,0,0);

        duration += Time.deltaTime;
        if (duration > 10) gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        box_collider.enabled = false;
        animator.SetTrigger("explore"); 
    }

    public void SetDirection(float _direction_)
    {
        duration = 0;
        direction = _direction_;
        gameObject.SetActive(true);
        hit = false;
        box_collider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction_ )
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);    

    }

    void DeActivate()
    {
        gameObject.SetActive(false);

    }
}
 