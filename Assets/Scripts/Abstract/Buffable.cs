using UnityEngine;
using System.Collections;

public abstract class Buffable : MonoBehaviour
{
    public abstract float Speed { get; set; }
    public abstract Sprite StartSprite { get; set; }
    public abstract Vector2 Destination { get; set; }
}
