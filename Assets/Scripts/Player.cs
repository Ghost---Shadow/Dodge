using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float Speed = 8f;
    Vector3 target;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
