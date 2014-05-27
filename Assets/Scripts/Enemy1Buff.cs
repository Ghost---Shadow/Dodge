using UnityEngine;
using System.Collections;

public class Enemy1Buff : MonoBehaviour
{
    public Sprite sprite;

    Enemy enemy;
    float originalSpeed;
    Sprite originalSprite;
    SpriteRenderer spriteRenderer;
    float nextMoveTime;

    // Use this for initialization
    void Start()
    {
        enemy = (Enemy)gameObject.GetComponent(typeof(Enemy));
        originalSpeed = enemy.Speed;

        spriteRenderer = (SpriteRenderer)gameObject.GetComponent(typeof(SpriteRenderer));
        originalSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextMoveTime)
        {
            nextMoveTime += enemy.WaitTime; 
            int buffChance = Random.Range(0, 2);
            if (buffChance == 0)
            {
                enemy.Speed = originalSpeed * 2.0f;
                spriteRenderer.sprite = sprite;
            }
            else
            {
                enemy.Speed = originalSpeed;
                spriteRenderer.sprite = originalSprite;
            }
        }
    }
}
