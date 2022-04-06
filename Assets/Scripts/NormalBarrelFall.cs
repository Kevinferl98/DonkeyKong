using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBarrelFall : MonoBehaviour
{
    public GameObject barrel; 

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 4, true);
        Physics2D.IgnoreLayerCollision(7, 1, true);
        Physics2D.IgnoreLayerCollision(7, 2, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
        if (GameManager.Instance().restart == true)
            Destroy(gameObject);
    }

    private IEnumerator fall()
    {
        Physics2D.IgnoreLayerCollision(7, 4, true);
        yield return new WaitForSeconds(0f);
        Physics2D.IgnoreLayerCollision(7, 4, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
            Instantiate(barrel, transform.position, Quaternion.identity);
        }
    }
}
