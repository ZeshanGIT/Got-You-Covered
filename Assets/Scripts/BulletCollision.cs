using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Boundary") Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
