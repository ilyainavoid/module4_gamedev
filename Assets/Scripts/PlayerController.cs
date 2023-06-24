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
    public bool isMoving = false;


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

        if (Input.mousePosition.x < Screen.width / 2) {
            isLeftDirected = true;
            isRightDirected = false;
        }
        if (Input.mousePosition.x >= Screen.width / 2)
        {
            isRightDirected = true;
            isLeftDirected = false;
        }

        if (moveX != 0 || moveY != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            animator.SetTrigger("player_castsMagic");
        }

        animator.SetBool("player_RightDirected", isRightDirected);
        animator.SetBool("player_LeftDirected", isLeftDirected);
        animator.SetBool("player_isMoving", isMoving);
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
