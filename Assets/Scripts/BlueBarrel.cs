using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBarrel : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Fall;
    public float speed = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(fall());  
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
        if (GameManager.Instance().restart == true)
            Destroy(gameObject);
    }

    public double GetRandomNumber(float minimum, float maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    private IEnumerator fall()
    {
        yield return new WaitForSeconds((float)GetRandomNumber(2,5));
        Instantiate(Fall, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && collision.gameObject.layer != LayerMask.NameToLayer("TransparentFX"))
        {
            rb.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}
