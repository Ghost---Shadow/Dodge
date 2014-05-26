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

    // Random destination to move towards
    private Vector3 destination;

    // Use this for initialization
    void Start()
    {
        // Find the background to use for bounds
        GameObject background = GameObject.Find("Background");
        if (!background)
            Debug.LogError("Background not found!");

        // Set bounds based on the background renderer
        minX = background.renderer.bounds.min.x;
        minY = background.renderer.bounds.min.y;
        maxX = background.renderer.bounds.max.x;
        maxY = background.renderer.bounds.max.y;

        // Choose an initial random destination
        destination = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        // Move to a random location every X seconds
        if (Time.time >= nextMoveTime)
        {
            nextMoveTime += WaitTime;
            destination = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        transform.position = Vector2.MoveTowards(transform.position, destination, Speed * Time.deltaTime);
    }
}
