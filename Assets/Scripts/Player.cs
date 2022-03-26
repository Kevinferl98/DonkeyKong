using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedMovement = 1;
    public float JumpForce = 1;
    public float speed = 2f;
    private bool scala = false;
    private bool jumping = false;
    private bool ground = true;
    private Vector2 start = new Vector2(-4.5f, -4f);

    public Animator animator;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void HorizontalMovement()
    {
        float movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speedMovement;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") /*&& Mathf.Abs(_rigidbody.velocity.y) < 0.001f*/&& ground==true && scala == false)
        {
            animator.SetBool("isJumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            jumping = true;
            ground = false;
        }
    }
    private void Ladder()
    {
        if (scala == true && jumping == false)
        {
            _rigidbody.gravityScale = 0;
            float movement_vertical = Input.GetAxis("Vertical");
            transform.position += new Vector3(0, movement_vertical, 0) * Time.deltaTime * speed;
        }
        else if (scala == false)
            _rigidbody.gravityScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
        Ladder();
    }

    private IEnumerator Death()
    {
        Physics2D.IgnoreLayerCollision(0, 2, true);
        animator.SetBool("hit", true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("hit", false);
        Physics2D.IgnoreLayerCollision(0, 2, false);
        transform.position = start;
        GameManager.Instance().Restart();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            animator.SetBool("isJumping", false);
            jumping = false;
            if (scala == true && collision.gameObject.transform.position.y >= (transform.position.y+0.3f))
                animator.SetBool("finish", true);
            if(scala==false)
                animator.SetBool("finish", false);
            if (collision.gameObject.transform.position.y < transform.position.y)
                ground = true;
        }
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Debug.Log("Colpito Mario");
            StartCoroutine(Death());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder") && jumping == false && collision.gameObject.transform.position.y+0.2f >= transform.position.y)
        {
            scala = true;
            animator.SetBool("ladder", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            scala = false;
            animator.SetBool("ladder", false);
        }
    }
}
