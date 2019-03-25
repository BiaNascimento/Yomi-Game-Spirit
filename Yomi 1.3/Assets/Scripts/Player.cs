using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float jumpForce, runVelocity, groundRadiusCollison = 0.1f;
    private bool isGameOver, isGrounded, jump, doubleJump;
    private Rigidbody2D rb;
    private Transform checkGround;
    public GameObject projectile;
    public float timeToAttack = 0.8f;
    private bool canAttack = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 4;
        checkGround = GameObject.Find("GroundCheck").transform;
    }
    void Update()
    {
        CheckInputs();
        isGrounded = Physics2D.OverlapCircle(checkGround.position, groundRadiusCollison, LayerMask.GetMask("Ground"));
        if (isGrounded)
            doubleJump = false;
        if (isGameOver)
            GameOverTemp();
    }
    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.A) && GameManager.haveProjectile && canAttack)
            Attack();
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.haveDoubleJump)
            Jump();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(runVelocity * Time.deltaTime, rb.velocity.y);
        if (jump)
        {
            jump = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);
            if (!doubleJump && !isGrounded)
            {
                doubleJump = true;
            }
        }
    }
    void Jump()
    {
        if (isGrounded || !doubleJump)
            jump = true;
    }
    void Attack()
    {
        Instantiate(projectile, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
        StartCoroutine("WaitTime");
    }
    IEnumerator WaitTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(timeToAttack);
        canAttack = true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
            isGameOver = true;
    }
    void GameOverTemp()
    {
        Camera.main.transform.parent = null;
        this.gameObject.SetActive(false);
    }
}