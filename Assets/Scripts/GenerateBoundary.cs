using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoundary : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject boundary;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Instantiate(boundary, new Vector3(screenBounds.x, 0), Quaternion.Euler(0, 0, 90)).transform.parent = transform;
        Instantiate(boundary, new Vector3(-screenBounds.x, 0), Quaternion.Euler(0, 0, 90 + 180)).transform.parent = transform;
        Instantiate(boundary, new Vector3(0, screenBounds.y, 0), Quaternion.Euler(0, 0, 180)).transform.parent = transform;
        Instantiate(boundary, new Vector3(0, -screenBounds.y, 0), Quaternion.identity).transform.parent = transform;
    }
}
