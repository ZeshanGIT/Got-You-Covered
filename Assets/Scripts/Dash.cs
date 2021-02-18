using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public GameObject RedPlayer, GreenPlayer;
    public Text dashPrompt;
    int dash = 10;
    public float animSpeed = 0.5f;
    public bool isDashing = false;
    int DASHING_LAYER = 15;
    int RED_PLAYER = 8;
    int GREEN_PLAYER = 9;

    void Start()
    {
        dashPrompt.fontSize = Screen.width / 25;
    }

    public void AddDash()
    {
        ++dash;
        dashPrompt.enabled = true;
    }

    void Update()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.Return) && dash > 0)
        {
            StartCoroutine(DoDash());
        }
    }

    IEnumerator DoDash()
    {

        Debug.Log("Dashing....");
        isDashing = true;

        RedPlayer.layer = DASHING_LAYER;
        GreenPlayer.layer = DASHING_LAYER;

        Vector2 playerRedDesiredPos = new Vector2(-0.1f, 0);
        Vector2 playerGreenDesiredPos = new Vector2(0.1f, 0);

        Vector2 redPlayerPos = new Vector2(RedPlayer.transform.position.x, RedPlayer.transform.position.y);
        Vector2 greenPlayerPos = new Vector2(GreenPlayer.transform.position.x, GreenPlayer.transform.position.y);

        float timeLeft = 1.5f;

        while (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            redPlayerPos = new Vector2(RedPlayer.transform.position.x, RedPlayer.transform.position.y);
            greenPlayerPos = new Vector2(GreenPlayer.transform.position.x, GreenPlayer.transform.position.y);

            Vector2 redPlayerNewPos = Vector2.MoveTowards(redPlayerPos, playerRedDesiredPos, 0.01f);
            RedPlayer.transform.position = redPlayerNewPos;

            Vector2 greenPlayerNewPos = Vector2.MoveTowards(greenPlayerPos, playerGreenDesiredPos, 0.01f);
            GreenPlayer.transform.position = greenPlayerNewPos;

            RedPlayer.transform.rotation = Quaternion.Lerp(RedPlayer.transform.rotation, Quaternion.Euler(0, 0, 90), 0.1f);
            GreenPlayer.transform.rotation = Quaternion.Lerp(GreenPlayer.transform.rotation, Quaternion.Euler(0, 0, -90), 0.1f);

            yield return null;
        }

        GameObject playersParent = new GameObject();
        RedPlayer.transform.SetParent(playersParent.transform, true);
        GreenPlayer.transform.SetParent(playersParent.transform, true);

        Shooting redShooter = RedPlayer.GetComponent<Shooting>();
        Shooting greenShooter = GreenPlayer.GetComponent<Shooting>();

        float ogShootRate = redShooter.shootRate;

        redShooter.shootRate = 1f;
        greenShooter.shootRate = 1f;

        timeLeft = 4f;
        while (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            playersParent.transform.Rotate(new Vector3(0f, 0, 2f), Space.World);
            redShooter.Shoot();
            greenShooter.Shoot();
            yield return null;
        }

        Debug.Log("Exiting while block");

        RedPlayer.transform.SetParent(null, true);
        GreenPlayer.transform.SetParent(null, true);
        Destroy(playersParent);

        redShooter.shootRate = ogShootRate;
        greenShooter.shootRate = ogShootRate;

        --dash;
        isDashing = false;
        dashPrompt.enabled = dash > 0;

        RedPlayer.layer = RED_PLAYER;
        GreenPlayer.layer = GREEN_PLAYER;
        Debug.Log("Exiting coroutine");

    }
}
