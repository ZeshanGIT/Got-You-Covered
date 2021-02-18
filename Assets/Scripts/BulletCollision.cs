using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    SpawnEnemies enemySpawn;

    void Start()
    {
        enemySpawn = GameObject.Find("SpawnEnemies").GetComponent<SpawnEnemies>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Boundary")
        {
            string tag = collision.gameObject.tag;
            Destroy(collision.gameObject);
            enemySpawn.Spawn(tag);
        }
        Destroy(gameObject);
    }
}
