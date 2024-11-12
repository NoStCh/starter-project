using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool hasaxe;

    void Start()
    {
        hasaxe = false;
    }

    void Update()
    {
        if (hasaxe)
        {
            Destroy(gameObject);
        }
    }
}