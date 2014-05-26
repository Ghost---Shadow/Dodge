using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public float EdgeBuffer = 70f;  // The border width at the screen edge in which the movement will work
    public float Speed = 15f;       // Speed of the camera movement                               

    float width;
    float height;
    Vector2 lowerBounds;
    Vector2 upperBounds;

    // Use this for initialization
    void Start()
    {
        // Start the camera centered on the player
        Vector2 PlayerPos = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y, transform.position.z);

        // Find the cameras height and width
        height = camera.orthographicSize;
        width = height * camera.aspect;

        // Get the background to use for the camera bounds
        GameObject background = GameObject.Find("Background");
        if (!background)
            Debug.LogError("Background could not be found!");

        // Find the lower and upper bounds of the map
        lowerBounds = new Vector2(background.renderer.bounds.min.x, background.renderer.bounds.min.y);
        upperBounds = new Vector2(background.renderer.bounds.max.x, background.renderer.bounds.max.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if on the right edge
        if (Input.mousePosition.x >= Screen.width - EdgeBuffer &&
            Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.y <= Screen.height &&
            Input.mousePosition.y >= 0)
            transform.position += Vector3.right * Time.deltaTime * Speed;

        // Check if on the left edge
        if (Input.mousePosition.x <= EdgeBuffer &&
            Input.mousePosition.x >= 0 &&
            Input.mousePosition.y <= Screen.height &&
            Input.mousePosition.y >= 0)
            transform.position += Vector3.left * Time.deltaTime * Speed;

        // Check if on the top edge
        if (Input.mousePosition.x >= 0 &&
            Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.y >= Screen.height - EdgeBuffer &&
            Input.mousePosition.y <= Screen.height)
            transform.position += Vector3.up * Time.deltaTime * Speed;

        // Check if on the bottom edge
        if (Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.x >= 0 &&
            Input.mousePosition.y <= EdgeBuffer &&
            Input.mousePosition.y >= 0)
            transform.position += Vector3.down * Time.deltaTime * Speed;
    }

    void LateUpdate()
    {
        // Center on player
        if (Input.GetButton("Jump"))
        {
            GameObject Player = GameObject.Find("Player");

            if (Player != null)
            {
                Vector3 PlayerPos = Player.transform.position;
                transform.position = new Vector3(PlayerPos.x, PlayerPos.y, transform.position.z);
            }
        }

        // Make sure the camera doesn't go further left or right than the size of the map
        if (transform.position.x - width <= lowerBounds.x)
            transform.position = new Vector3(lowerBounds.x + width, transform.position.y, transform.position.z);
        else if (transform.position.x + width >= upperBounds.x)
            transform.position = new Vector3(upperBounds.x - width, transform.position.y, transform.position.z);

        // Make sure the camera doesn't go further up or down than the size of the map
        if (transform.position.y + height >= upperBounds.y)
            transform.position = new Vector3(transform.position.x, upperBounds.y - height, transform.position.z);
        else if (transform.position.y - height <= lowerBounds.y)
            transform.position = new Vector3(transform.position.x, lowerBounds.y + height, transform.position.z);
    }
}
