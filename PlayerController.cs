using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftBoundPadding = 10f;
    [SerializeField] float rightBoundPadding = 10f;
    [SerializeField] float bottomBoundPadding = 10f;
    [SerializeField] float upBoundPadding = 10f;

    InputAction moveAction;
    Vector3 moveVector;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        }
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        Vector3 newPos = transform.position + moveVector * (moveSpeed * Time.deltaTime);
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y+ bottomBoundPadding, maxBounds.y- upBoundPadding);
        transform.position = newPos;
    }
}