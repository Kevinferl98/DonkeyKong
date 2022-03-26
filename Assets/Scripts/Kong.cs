using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Kong : MonoBehaviour
{
    public GameObject prefab;
    public GameObject empty;
    public float minTime = 2f;
    public float maxTime = 5f;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    public double GetRandomNumber(float minimum, float maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Instantiate(prefab, empty.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds((float)GetRandomNumber(1,3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
