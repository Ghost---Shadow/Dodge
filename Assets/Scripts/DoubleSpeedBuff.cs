using UnityEngine;
using System.Collections;

public class DoubleSpeedBuff : MonoBehaviour
{
    public Sprite buffSprite;
    public int buffChance = 2;  // The lower the number the greater the chance

    Enemy enemy;
    float originalSpeed;
    Sprite originalSprite;
    SpriteRenderer spriteRenderer;
    float nextMoveTime;

    // Use this for initialization
    void Start()
    {
        buffChance = 2;
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
            int chance = Random.Range(0, buffChance);
            if (chance == 0)
            {
                enemy.Speed = originalSpeed * 2.0f;
                spriteRenderer.sprite = buffSprite;
            }
            else
            {
                enemy.Speed = originalSpeed;
                spriteRenderer.sprite = originalSprite;
            }
        }
    }
}
