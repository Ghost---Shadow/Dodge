using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour
{
    static int DeathCount;

    public static void IncrementDeath()
    {
        DeathCount++;
        Debug.Log(DeathCount);
    }
}
