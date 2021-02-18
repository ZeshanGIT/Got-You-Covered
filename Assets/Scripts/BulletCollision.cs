using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    SpawnEnemies enemySpawn;
    Scorer scorer;

    void Start()
    {
        enemySpawn = GameObject.Find("SpawnEnemies").GetComponent<SpawnEnemies>();
        scorer = GameObject.Find("Scorer").GetComponent<Scorer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.tag != "Boundary")
        {
            scorer.AddScore();
            Animator animator = collisionObject.GetComponent<Animator>();
            animator.SetBool("Die", true);
            collisionObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collisionObject.GetComponent<Collider2D>().enabled = false;
            Destroy(collisionObject, 1f);
        }
        Destroy(gameObject);
    }
}
