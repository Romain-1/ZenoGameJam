using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugSpawner : MonoBehaviour
{
    public int count = 5;
    public float range = 5;
    public GameObject bugPrefab;

    public LevelScene level;

    private Vector3 GetRandomPosition()
    {
        float r = range * Mathf.Sqrt(Random.Range(0f, 1f));
        float theta = Random.Range(0f, 1f) * 2 * Mathf.PI;

        return new Vector3(transform.position.x + r * Mathf.Cos(theta), transform.position.y + r * Mathf.Sin(theta),
            transform.position.z);
    }

    IEnumerator SpawnMothsCoroutine()
    {
        for (int i = 0; i < count; ++i)
        {
            Instantiate(bugPrefab, GetRandomPosition(), Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            yield return new WaitForSeconds(Random.Range(0.01f, 0.05f));
        }
    }

    void Start()
    {
        level.AddMoth(count);
        StartCoroutine(SpawnMothsCoroutine());
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range, 1);
    }
}
