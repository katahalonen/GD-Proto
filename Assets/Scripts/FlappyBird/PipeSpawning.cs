using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawning : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] float minHeight = 1f;
    [SerializeField] float maxHeight = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);
    }
    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    void Spawn() 
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
