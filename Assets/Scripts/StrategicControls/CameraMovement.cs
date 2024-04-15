using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveCamera;
    [SerializeField] private float movementSpeed;
    private Vector2 movementDirection;

    private void Update()
    {
        movementDirection = moveCamera.action.ReadValue<Vector2>();
        Vector3 movementVelocity = new Vector3(movementDirection.x, 0, movementDirection.y) * movementSpeed;
        transform.position += movementVelocity * Time.deltaTime;
    }
}
