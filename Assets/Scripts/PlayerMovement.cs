using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rigidbody2D;
    ActivePlayer activePlayer;
    bool isActive;
    Vector2 movement;
    Vector2 playerPos;
    Vector2 mousePos;
    Camera cam;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        activePlayer = GetComponent<ActivePlayer>();
        cam = Camera.main;
    }

    void Update()
    {
        isActive = activePlayer.isActive;
        if (!isActive) return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerPos = rigidbody2D.position;
        Vector3 tempMousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(tempMousePos.x, tempMousePos.y, 1));
    }

    void FixedUpdate()
    {



        if (!isActive)
        {
            rigidbody2D.velocity = Vector2.zero;
            return;
        }

        Vector2 lookDir = mousePos - rigidbody2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody2D.rotation = angle;

        rigidbody2D.AddForce(movement * speed);
    }
}
