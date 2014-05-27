using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float Speed = 8f;
    Vector3 target;
    bool isSafe = true;

    // Use this for initialization
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && !isSafe)
        {
            Dead();
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SafeZone")
            isSafe = true;
        
        if (other.gameObject.name == "SafeZone Top")
        {
            Debug.Log("You Win!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "SafeZone")
            isSafe = false;
    }

    void Dead()
    {
        DeathScript.IncrementDeath();
    }
}
