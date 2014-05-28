using UnityEngine;
using System.Collections;

public class Player : Buffable
{
    public float MoveSpeed = 8f;
    Vector3 target;
    bool isSafe = true;

    public override Vector2 Destination
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    public override Sprite StartSprite
    {
        get
        {
            return ((SpriteRenderer)GetComponent(typeof(SpriteRenderer))).sprite;
        }
        set
        {
            ((SpriteRenderer)GetComponent(typeof(SpriteRenderer))).sprite = value;
        }
    }

    public override float Speed
    {
        get
        {
            return MoveSpeed;
        }
        set
        {
            MoveSpeed = value;
        }
    }

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
        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
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
        {
            SafeZone safeZone = (SafeZone)other.gameObject.GetComponent(typeof(SafeZone));
            safeZone.Entered();
            isSafe = true;
        }

        if (other.gameObject.name == "SafeZone Top")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            SafeZone safeZone = (SafeZone)other.gameObject.GetComponent(typeof(SafeZone));
            safeZone.Left();
            isSafe = false;
        }
    }

    void Dead()
    {
        DeathScript.IncrementDeath();
    }
}
