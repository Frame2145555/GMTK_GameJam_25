using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Animator animator;
    Vector2 movement;

    void Awake()
    {

        animator = GetComponent<Animator>();
        Auxiliary.CheckInspectorNotAssign(animator);
    }

    void Update()
    {
        // Read input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        // Apply movement
        TryMove(movement);

        // Update animator
        if (animator)
        {

            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            animator.SetBool("IsMoving", movement.sqrMagnitude > 0.01f);
        }
    }
    void TryMove(Vector2 direction)
    {
        float collisionCheckDistance = 0.05f;
        if (direction == Vector2.zero) return;

        Vector3 targetPos = transform.position + (Vector3)(direction * moveSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, collisionCheckDistance, wallLayer);
        if (!hit)
        {
            transform.position = targetPos;
        }
    }
}