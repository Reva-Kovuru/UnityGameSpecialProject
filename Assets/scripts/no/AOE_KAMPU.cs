using UnityEngine;

public class AOE_KAMPU : MonoBehaviour
{
   [SerializeField] private GameObject image;
   private float flickerTime ;
   public float cooldown = 5f;
   public float duration = 3f;
   
    
    void Update()
    {
       flickerTime -= Time.deltaTime;
       if (flickerTime <= 0)
       {
           flickerTime = cooldown;
           Instantiate(image, transform.position, transform.rotation,transform);
           
       }
    }
    
    
        
    
}
