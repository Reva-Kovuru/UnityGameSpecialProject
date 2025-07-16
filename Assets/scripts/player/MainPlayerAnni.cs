using UnityEngine;

public class MainPlayer_Anni : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 5 ;
    public float immunityTime;
    public float immunityDuration; // Time in seconds to be invulnerable after taking damage
    public Vector3 playerdirect;
    public Animator ani;
    public static MainPlayer_Anni I;

    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);
        }
        else{
            I = this;
        }
    }

    void Start()
    {
        MAINPLAYER_HP = MAINPLAYER_FULLHP;
        UI_ALL.I.UpdateHealthSlider(MAINPLAYER_HP);
    }

    
    void FixedUpdate()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        playerdirect = new  Vector3(X,Y).normalized;
        ani.SetFloat("goX",X);
        ani.SetFloat("goY",Y);
       
        rb.linearVelocity = new  Vector2(playerdirect.x * Speed * Time.deltaTime,playerdirect.y * Speed * Time.deltaTime);
    
        if (playerdirect == Vector3.zero){
            ani.SetBool("move",false);
        }
        else{
            ani.SetBool("move",true);
        }
        
        if(immunityTime > 0){
            immunityTime -= Time.deltaTime; // Decrease the immunity time
        }
        else{
            isInvulnerable = false; // Reset the invulnerability flag when immunity time is over
        }
    
    }
    private bool isInvulnerable; // Flag to check if the player is invulnerable
    public float MAINPLAYER_FULLHP;
    public float MAINPLAYER_HP;
    public void TakeDamage(float damage)
    {
        if(!isInvulnerable)
        {
            isInvulnerable = true;
            immunityTime = immunityDuration; // Set the invulnerability flag to true
            MAINPLAYER_HP -= damage;
            UI_ALL.I.UpdateHealthSlider(MAINPLAYER_HP);
            if (MAINPLAYER_HP <= 0)
            {
                gameObject.SetActive(false);
                DataLoggerScript.I.FinalSave();
                EventManager.I.PlayerDied();
            }
        }
    }
}