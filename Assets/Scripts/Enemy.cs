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

        // Move to a random location every X seconds
        InvokeRepeating("MoveRandom", 0, WaitTime);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, Speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            destination = destination * -1;
    }
}
