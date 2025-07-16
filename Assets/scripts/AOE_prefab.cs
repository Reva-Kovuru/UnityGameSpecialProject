using UnityEngine;

public class AOE_prefab : MonoBehaviour
{
    public weapon weaponA;

    private Vector3 size;

    private float timer;
    void Start()
    {
        weaponA = GameObject.Find("AOE").GetComponent<weapon>();
        //Destroy(gameObject, weaponA.duration); // Destroy the object after 0.5 seconds
        size =Vector3.one;
        transform.localScale = size;
        timer = weaponA.duration;
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, size, Time.deltaTime * 5f);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            size = Vector3.zero;
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject); // Destroy the object when the scale is zero
            }
        }
    }
}
