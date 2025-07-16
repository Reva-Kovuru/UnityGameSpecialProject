using UnityEngine;
using UnityEngine.InputSystem;


public class ShooterRotator : MonoBehaviour
{
    float counter = 0;
    float opp = 0f;
    float adj = 0f;
    float rotDeg = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current == null)
        {
            Debug.LogWarning("Mouse not connected or Input System not initialized.");
            return;
        }
        Vector2 inpmouse = Mouse.current.position.ReadValue();
        float camZ = Camera.main.transform.position.z;
        Vector3 scenePos = Camera.main.ScreenToWorldPoint(new Vector3(inpmouse.x, inpmouse.y, -camZ));
        counter += Time.deltaTime;
        if(counter > 0.001f){
            opp =  scenePos.y - transform.position.y;
            adj =  scenePos.x - transform.position.x;
            rotDeg = Mathf.Atan2(opp, adj) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotDeg);
            counter = 0f;
        }
        }
    }

