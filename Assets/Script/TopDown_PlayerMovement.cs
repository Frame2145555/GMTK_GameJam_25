using UnityEngine;
using UnityEngine.InputSystem;

public class TopDown_PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = input * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        anim.SetBool("IsWalking", true);
        if(context.canceled)
        {
            anim.SetBool("IsWalking", false);
            anim.SetFloat("LastInputX", input.x);
            anim.SetFloat("LastInputY", input.y);
        }
        input = context.ReadValue<Vector2>();
        anim.SetFloat("inputx", input.x);
        anim.SetFloat("inputy", input.y);
    }

    
}

