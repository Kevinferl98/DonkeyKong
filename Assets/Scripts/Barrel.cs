using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
        if (GameManager.Instance().restart == true)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Barrier1"))
        {
            rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
            Debug.Log("Fatto");
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            rb.AddForce(collision.transform.right * speed * -1, ForceMode2D.Impulse);
            Debug.Log("Fatto");
        }*/
        if (collision.gameObject.CompareTag("Platform") && collision.gameObject.layer != LayerMask.NameToLayer("TransparentFX"))
        {
            rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}
