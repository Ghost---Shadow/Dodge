using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour
{
    static int DeathCount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void IncrementDeath()
    {
        DeathCount++;
        Debug.Log(DeathCount);
    }
}
