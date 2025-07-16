using UnityEngine;
using UnityEngine.InputSystem;

public class playerAttacksScript : MonoBehaviour
{
    public static playerAttacksScript I;
    [SerializeField] GameObject primaryBulletPrefab;
    [SerializeField] float fireRate = 100f;
    // [SerializeField] InputAction primaryShootAction;
    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);
        }
        else{
            I = this;
        }
    }

    float primaryCounter = 0f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        primaryCounter += fireRate * Time.deltaTime;
        if(Mouse.current.leftButton.isPressed){
            if(primaryCounter > 1f){
                Instantiate(primaryBulletPrefab, transform.position, transform.rotation);
                // Telling Datalogger that a bullet has been fired.
                DataLoggerScript.I.OnBulletFired();
                primaryCounter = 0f;
            }
        }
    }
}
