using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 30f;
    Vector3 cursorPos;
    Vector3 distVector;
    private float counter = 0f;
    [SerializeField] float maxTime = 2f;
    void Start()
    {
        Vector2 inpmouse = Mouse.current.position.ReadValue();
        float camZ = Camera.main.transform.position.z;
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(inpmouse.x, inpmouse.y, -camZ));
        // scenePos.Normalize();
        distVector = cursorPos - transform.position;
        distVector.Normalize();
    }

    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, cursorPos, bulletSpeed * Time.deltaTime);
        transform.position += distVector * bulletSpeed * Time.deltaTime;

        counter += Time.deltaTime;
        if(counter >= maxTime){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" ||
            collision.gameObject.tag == "Mob" ||
            collision.gameObject.tag == "First_Bound" ||
            collision.gameObject.tag == "Second_Bound" ||
            collision.gameObject.tag == "Boundaries"){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" ||
            collision.gameObject.tag == "Mob" ||
            collision.gameObject.tag == "Boundaries"){
            Destroy(gameObject);
        }
    }
}

