using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public string PlayerTag;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        // return;
        GameObject collisionObject = collision2D.gameObject;
        if (collisionObject.tag == PlayerTag)
        {
            collisionObject.GetComponent<Collider2D>().enabled = false;
            collisionObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collisionObject.GetComponent<Animator>().SetBool("Die", true);

            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Animator>().SetBool("Die", true);

            Destroy(gameObject, 1f);
            Destroy(collisionObject, 1f);
        }
    }
}
