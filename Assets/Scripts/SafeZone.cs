using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Sprite))]
[RequireComponent(typeof(SpriteRenderer))]
public class SafeZone : MonoBehaviour
{
    public Sprite EnteredTexture;
    public Sprite LeftTexture;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    public void Entered()
    {
        spriteRenderer.sprite = EnteredTexture;
    }

    public void Left()
    {
        spriteRenderer.sprite = LeftTexture;
    }
}
