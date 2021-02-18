using UnityEngine;
using UnityEngine.UI;
public class Scorer : MonoBehaviour
{

    public Text scoreboard;
    int score = 0;

    void Start()
    {
        scoreboard.fontSize = Screen.width / 15;
    }

    public void AddScore()
    {
        ++score;
        scoreboard.text = score.ToString();
    }
}
