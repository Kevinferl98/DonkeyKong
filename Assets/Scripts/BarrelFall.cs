using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 4, true);
        Physics2D.IgnoreLayerCollision(6, 2, true);
        Physics2D.IgnoreLayerCollision(6, 1, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
        if (GameManager.Instance().restart == true)
            Destroy(gameObject);
    }
}
