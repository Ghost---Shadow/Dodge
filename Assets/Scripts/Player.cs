using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, Buffable
{
    public float MoveSpeed = 8f;
    Vector2 target;
    bool isSafe = true;
    Vector2 upperBounds;
    Vector2 lowerBounds;

    Vector2 Buffable.Destination
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

    Sprite Buffable.StartSprite
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

    float Buffable.Speed
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

	float Buffable.Size
	{
		get
		{
			return transform.localScale.magnitude;
		}
		set
		{
			transform.localScale = new Vector3(value,value,value);
		}
	}

    // Use this for initialization
    void Start()
    {
        target = transform.position;

        GameObject background = GameObject.Find("Background");
        if (!background)
            Debug.LogError("Background could not be found.");

        upperBounds = background.renderer.bounds.max;
        lowerBounds = background.renderer.bounds.min;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
        {
            if (Input.GetAxis("Vertical") >= 0.2 || Input.GetAxis("Vertical") <= -0.2)
                target.y = Input.GetAxis("Vertical") * .2f + transform.position.y;
            if (Input.GetAxis("Horizontal") >= 0.2 || Input.GetAxis("Horizontal") <= -0.2)
                target.x = Input.GetAxis("Horizontal") * .2f + transform.position.x;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        // Keep player on the map
        if (transform.position.x > upperBounds.x)
            transform.position = new Vector2(upperBounds.x, transform.position.y);
        else if (transform.position.x < lowerBounds.x)
            transform.position = new Vector2(lowerBounds.x, transform.position.y);

        if (transform.position.y > upperBounds.y)
            transform.position = new Vector2(transform.position.x, upperBounds.y);
        else if (transform.position.y < lowerBounds.y)
            transform.position = new Vector2(transform.position.x, lowerBounds.y);
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

        if (other.gameObject.tag == "Enemy" && !isSafe)
        {
            Dead();
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
