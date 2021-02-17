using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.layer);
        Destroy(gameObject);
    }
}
