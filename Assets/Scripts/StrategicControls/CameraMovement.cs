using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveCamera;
    [SerializeField] private float movementSpeed;
    private Vector2 movementDirection;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private void Update()
    {
        movementDirection = moveCamera.action.ReadValue<Vector2>();
        Vector3 movementVelocity = new Vector3(movementDirection.x, 0, movementDirection.y) * movementSpeed;
        Vector3 newPosition = transform.position + movementVelocity * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;
    }
}