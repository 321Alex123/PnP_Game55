using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectByClick : MonoBehaviour
{
    [SerializeField] private InputActionReference selectObject;
    [SerializeField] private LayerMask clickableLayers;

    static public List<GameObject> selectedDrones = new List<GameObject>();
    private GameObject selectedEnemy;

    private void Awake()
    {
        selectObject.action.performed += SelectObject;
    }

    private void SelectObject(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                SelectDrone(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                SelectEnemy(hit.collider.gameObject);
            }
        }
    }

    static public void SelectDrone(GameObject drone)
    {
        if (selectedDrones.Contains(drone))
        {
            selectedDrones.Remove(drone);
            drone.GetComponent<SelectionIndication>().ChangeIndicator(false);
        }
        else
        {
            selectedDrones.Add(drone);
            drone.GetComponent<SelectionIndication>().ChangeIndicator(true);
        }
    }

    private void SelectEnemy(GameObject enemy)
    {
        if (enemy == selectedEnemy)
        {
            selectedEnemy = null;
        }
        else
        {
            selectedEnemy = enemy;
        }
    }
}
