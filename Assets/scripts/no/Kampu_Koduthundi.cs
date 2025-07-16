using UnityEngine;

public class Kampu_Koduthundi : MonoBehaviour
{
    public AOE_KAMPU weapon; 
    void Start()
    {
        weapon = GameObject.Find("kampu kodthundi thatukogaluthava").GetComponent<AOE_KAMPU>();
    
            Destroy(gameObject,weapon.duration);
        
       
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
