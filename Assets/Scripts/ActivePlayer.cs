using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public bool firstPlayer;
    public bool isActive;
    void Start()
    {
        isActive = firstPlayer;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isActive = !isActive;
        }
    }
}
