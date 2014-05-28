using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Enemy))]
public class BuffManager : MonoBehaviour
{
    public float BuffDuration = 3;

    Component[] buffList;
    SpriteRenderer spriteRenderer;
    Sprite originalSprite;
    Enemy enemy;
    float originalSpeed;
    float originalWanderRadius;
    float nextBuffTime;

    // Use this for initialization
    void Start()
    {
        buffList = GetComponents(typeof(Buff));

        enemy = (Enemy)GetComponent(typeof(Enemy));
        originalSpeed = enemy.Speed;
        originalWanderRadius = enemy.WanderRadius;

        spriteRenderer = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        originalSprite = spriteRenderer.sprite;
    }

    void Update()
    {
        if (Time.time >= nextBuffTime)
        {
            int rand = Random.Range(0, buffList.Length + 5);
            Buff b;

            RemoveBuff();

            if (rand < buffList.Length)
            {
                b = (Buff)buffList[rand];
                b.ApplyBuff();
            }

            nextBuffTime += BuffDuration;
        }
    }

    void RemoveBuff()
    {
        enemy.Speed = originalSpeed;
        enemy.WanderRadius = originalWanderRadius;
        spriteRenderer.sprite = originalSprite;
    }
}
