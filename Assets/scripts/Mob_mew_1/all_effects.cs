using UnityEngine;

public class all_effects : MonoBehaviour
{
public Animator ani;
    void Start()
    {
        Destroy(gameObject, ani.GetCurrentAnimatorStateInfo(0).length);
    }
}
