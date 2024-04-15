using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class SetFlag : MonoBehaviour
{
    [SerializeField] private InputActionReference enableFlag;
    [SerializeField] private InputActionReference createFlag;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private GameObject flag;
    [SerializeField] private LayerMask clickableLayers;

    private void Awake()
    {
        enableFlag.action.performed += RemoveFlag;
        createFlag.action.performed += CreateFlag;
    }

    private void RemoveFlag(InputAction.CallbackContext context)
    {
        Destroy(flag);
    }

    private void CreateFlag(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            Destroy(flag);
            flag = Instantiate(flagPrefab, hit.point, Quaternion.identity);
            MoveDrones.position = flag.transform.position;
        }
    }
}
