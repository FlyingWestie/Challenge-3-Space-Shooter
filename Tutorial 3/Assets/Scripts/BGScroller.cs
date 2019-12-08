using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public float play;

    private Vector3 startPosition;
    void Start()
    {

        startPosition = transform.position;
    }

   
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        GameObject GameController = GameObject.Find("GameController");
        GameController gameScript = GameController.GetComponent<GameController>();
        if (gameScript.score >= 150)
        {
            transform.position = transform.position + startPosition;
            scrollSpeed = -5.0f;
        }
    }
}
