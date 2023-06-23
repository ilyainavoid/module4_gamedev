using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    public Weapon weapon;
    public Animator animator;
    public bool isLeftDirected = false;
    public bool isRightDirected = false;


    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.A)) {
            isLeftDirected = true;
            isRightDirected = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isRightDirected = true;
            isLeftDirected = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        animator.SetFloat("HorizontalMove", moveX);
        animator.SetFloat("VerticalMove", moveY);
        animator.SetBool("isGoingLeft", isLeftDirected);
        animator.SetBool("isGoingRight", isRightDirected);
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }
}
