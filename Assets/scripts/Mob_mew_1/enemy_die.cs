using UnityEngine;

public class enemy_die : MonoBehaviour
{
 
    public GameObject destroyEffectPrefab;
    public float damage;

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            MainPlayer_Anni.I.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
            // Telling the datalogger to log this death.
            DataLoggerScript.I.EnemyDead();
        }
        if(other.CompareTag("Player_Bullet")){
            Destroy(gameObject);
            Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
            // Telling the datalogger to log this death.
            DataLoggerScript.I.EnemyDead();
        }
    }
}
