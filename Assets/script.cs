using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class script : MonoBehaviour
{
    public InputActionReference actionReference;
    public GameObject gameObject;

    private void Awake()
    {
        actionReference.action.performed += Spawn;
    }

    private void Spawn(InputAction.CallbackContext callbackContext)
    {
        Instantiate(gameObject);
    }
}
