using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class BuffManager : MonoBehaviour
{
    public float BuffDuration = 3;

    Component[] buffList;
    SpriteRenderer spriteRenderer;
    Sprite originalSprite;
    Buffable buffable;
    float originalSpeed;
    float originalWanderRadius;
    float nextBuffTime;

    // Use this for initialization
    void Start()
    {
        buffList = GetComponents(typeof(Buff));

        buffable = (Buffable)GetComponent(typeof(Buffable));
        originalSpeed = buffable.Speed;

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
        buffable.Speed = originalSpeed;
        spriteRenderer.sprite = originalSprite;
    }
}
