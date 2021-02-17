using UnityEngine;

public class Shooting : MonoBehaviour
{
    Transform pointer;
    public GameObject bullet;
    public float bulletForce = 2f;
    public float shootRate = 0.8f;
    float timeLeft = 0f;
    ActivePlayer activePlayer;
    void Start()
    {
        pointer = transform.GetChild(0);
        activePlayer = GetComponent<ActivePlayer>();
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!activePlayer.isActive) return;
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
        {
            if (timeLeft <= 0f)
            {
                GameObject gameObject = Instantiate(bullet, pointer.position, pointer.rotation);
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(pointer.up * bulletForce, ForceMode2D.Impulse);
                timeLeft = 1 - shootRate;
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
