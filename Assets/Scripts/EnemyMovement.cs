using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum PlayerTag { RED, GREEN }
    public PlayerTag playerTag;
    public float speed = 0.05f;
    Transform player;
    Vector2 moveTo;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag == PlayerTag.RED ? "RedPlayer" : "GreenPlayer").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
