using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnityExample;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trash;

    private BoxCollider2D col;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        StartCoroutine(SpawnTrash(1f));
    }

    IEnumerator SpawnTrash(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        float x1= transform.position.x - col.bounds.size.x / 2f;

        float x2 = transform.position.x + col.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        Instantiate(trash[Random.Range(0, trash.Length)], temp,Quaternion.identity);

        StartCoroutine(SpawnTrash(Random.Range(1f, 2f)));
    }
}
