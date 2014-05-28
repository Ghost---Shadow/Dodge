using UnityEngine;
using System.Collections;

public class DoubleSpeedBuff : Buff
{
    public Sprite buffSprite;

    SpriteRenderer spriteRenderer;
    Enemy enemy;

    // Use this for initialization
    void Start()
    {
        enemy = (Enemy)gameObject.GetComponent(typeof(Enemy));
        spriteRenderer = (SpriteRenderer)gameObject.GetComponent(typeof(SpriteRenderer));
    }

    public override void ApplyBuff()
    {
        enemy.Speed *= 2.0f;
        spriteRenderer.sprite = buffSprite;
    }

    public override string BuffName
    {
        get 
        {
            return "Double Speed";
        }
    }
}
