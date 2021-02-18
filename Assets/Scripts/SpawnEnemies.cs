using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject RedEnemy;
    public GameObject GreenEnemy;
    static Vector2 screenBounds;

    string RED_TAG = "RedEnemy";
    string GREEN_TAG = "GreenEnemy";
    float timeleft = 0f;
    float spawnrate = 2f;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (timeleft <= 0)
        {
            timeleft = spawnrate;
            Spawn(Random.value > 0.5 ? RED_TAG : GREEN_TAG);
        }
        else timeleft -= Time.deltaTime;
    }

    public void Spawn(string tag)
    {
        float vert = Random.value > 0.5 ? 1 : -1;
        float hori = Random.value > 0.5 ? 1 : -1;
        Vector2 pos = new Vector2(vert * screenBounds.y, hori * screenBounds.y);
        pos = pos + Vector2.MoveTowards(pos, Vector2.zero, 0.000001f);

        if (tag == RED_TAG) Instantiate(RedEnemy, pos, Quaternion.identity);
        if (tag == GREEN_TAG) Instantiate(GreenEnemy, pos, Quaternion.identity);
    }
}
