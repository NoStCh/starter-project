using System;
using Unity.Mathematics;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject projectilePrefab;
    void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y);
    }

    private void OnTriggerStay(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject clone;
            clone = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
