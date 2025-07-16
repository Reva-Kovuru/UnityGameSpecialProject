using UnityEngine;

public class enemy : MonoBehaviour
{
    public SpriteRenderer SR;
    public float moveVagam;
    [SerializeField] private Rigidbody2D rb;
    private UnityEngine.Vector2 direction;


    void Update()
    {
        if(MainPlayer_Anni.I.gameObject.activeSelf )
        {   
            if (MainPlayer_Anni.I.transform.position.x > transform.position.x){
                SR.flipX = true;
            }
            else{
                SR.flipX = false;
            }
            direction = (MainPlayer_Anni.I.transform.position - transform.position).normalized;
            rb.linearVelocity = new UnityEngine.Vector2 ( direction.x * moveVagam, direction.y * moveVagam);
        }
        else {
            rb.linearVelocity = new UnityEngine.Vector2(0,0);
        }
    }
}