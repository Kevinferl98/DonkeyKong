using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public float minTime = 2f;
    public float maxTime = 4f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        anim.SetBool("launch", true);
        Instantiate(prefab, transform.position, Quaternion.identity);
        anim.SetBool("launch", false);
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
