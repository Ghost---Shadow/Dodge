using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float Speed = 4;     // Move speed
    public float WaitTime = 3;  // Time to wait before changing direction

    // Bounds to stay within
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;

    // Time to change destination
    private float nextMoveTime;

    // 
    private Vector3 destination;

    // Use this for initialization
    void Start()
    {
        GameObject background = GameObject.Find("Background");
        if (!background)
            Debug.LogError("Background not found!");

        minX = background.renderer.bounds.min.x;
        minY = background.renderer.bounds.min.y;
        maxX = background.renderer.bounds.max.x;
        maxY = background.renderer.bounds.max.y;
        destination = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextMoveTime)
        {
            Debug.Log(nextMoveTime);
            nextMoveTime += WaitTime;
            destination = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, Speed * Time.deltaTime);
    }
}
