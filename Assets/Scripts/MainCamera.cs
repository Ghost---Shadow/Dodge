using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public float EdgeBuffer = 70f;      // The border width at the screen edge in which the movement will work
    public float Speed = 15f;            // Speed of the camera movement                               

    // Use this for initialization
    void Start()
    {
        Vector2 PlayerPos = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y, transform.position.z);
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

        // Center on player
        if (Input.GetButton("Jump"))
        {
            GameObject Player = GameObject.Find("Player");

            if (Player != null)
            {
                Vector3 PlayerPos = Player.transform.position;
                transform.position = new Vector3(PlayerPos.x, PlayerPos.y, -10);
            }
        }
    }
}
