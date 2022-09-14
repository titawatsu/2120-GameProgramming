using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpAmplitude = 5f;

    [SerializeField] private SpriteRenderer sRenderer;

    [SerializeField] private GemColor playerColor;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    [SerializeField] private PowerupCollectible powerupCollectible;

    [SerializeField] private Collider2D playerCollider;


    [Header("For checking Ground")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float extraGroundCheckDistance = 0.5f;
    private bool isGrounded;
    private bool groundState;

    [SerializeField] private PlayerAnimationController animController;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Debug.Log(powerupCollectible.GetCollectibleType());
        
    }

    private void Update()
    {
        CheckGround();
        SetAnimParameter();
        SpriteDirection();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        //rb.velocity = (Vector2)transform.right * moveInput * rb.velocity.y;
        
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(transform.up * jumpAmplitude, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GemFunc gemFunc))
        {
            GemColor playerColor = gemFunc.color;

            switch (playerColor)
            {
                case GemColor.Red:
                    sRenderer.color = Color.red;
                    break;
                case GemColor.Green:
                    sRenderer.color = Color.green;
                    break;
                case GemColor.Blue:
                    sRenderer.color = Color.blue;
                    break;

            }
            Destroy(gemFunc.gameObject);
        }
    }

    private void SetAnimParameter()
    {
        animController.SetAnimationParameter(rb.velocity, isGrounded);
    }

    private void CheckGround()
    {
        var playerColliderBounds = playerCollider.bounds;

        var raycastHit = Physics2D.BoxCast(playerColliderBounds.center,
            playerColliderBounds.size, 
            0f, 
            Vector2.down, 
            extraGroundCheckDistance,
            groundLayers);

        isGrounded = raycastHit.collider != null;
    }

    private void SpriteDirection()
    {
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
