using UnityEngine;
using System.Collections;

public interface Buffable : MonoBehaviour
{
    float Speed { get; set; }
    Sprite StartSprite { get; set; }
    Vector2 Destination { get; set; }
}
