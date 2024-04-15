using UnityEngine;
using UnityEngine.InputSystem;

public class MoveDrones : MonoBehaviour
{
    [SerializeField] private InputActionReference moveDrones;
    static public Vector3 position;

    private void Awake()
    {
        moveDrones.action.performed += StartMoving;
    }

    private void StartMoving(InputAction.CallbackContext context)
    {
        foreach (var drone in SelectByClick.selectedDrones)
        {
            drone.GetComponent<Moving>().MoveToPosition(position);
        }
    }
}
