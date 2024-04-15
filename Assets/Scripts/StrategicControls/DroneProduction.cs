using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DroneProduction : MonoBehaviour
{
    [SerializeField] private Transform droneSpawn;
    [SerializeField] private Transform droneGathering;

    [SerializeField] private Button kamikazeProductionButton;
    [SerializeField] private Button APProductionButton;
    [SerializeField] private Button EMPProductionButton;

    [SerializeField] private GameObject kamikazeDronePrefab;
    [SerializeField] private GameObject APDronePrefab;
    [SerializeField] private GameObject EMPDronePrefab;

    [SerializeField] private Button droneButtonPrefab;

    [SerializeField] private GameObject productionPanel;
    [SerializeField] private GameObject selectionContent;
    [SerializeField] private InputActionReference openPanel;

    private void Awake()
    {
        openPanel.action.performed += OpenPanel;

        kamikazeProductionButton.onClick.AddListener(() => ProduceDrone(kamikazeDronePrefab));
        APProductionButton.onClick.AddListener(() => ProduceDrone(APDronePrefab));
        EMPProductionButton.onClick.AddListener(() => ProduceDrone(EMPDronePrefab));
    }

    private void OpenPanel(InputAction.CallbackContext context)
    {
        if (productionPanel.activeInHierarchy)
            productionPanel.SetActive(false);
        else
            productionPanel.SetActive(true);
    }

    public void ProduceDrone(GameObject dronePrefab)
    {
        GameObject drone = Instantiate(dronePrefab, droneSpawn.position, droneSpawn.rotation);
        CreateDroneButton(drone);
        drone.GetComponent<Moving>().MoveToPosition(droneGathering.position);
    }

    private void CreateDroneButton(GameObject drone)
    {
        Button droneButton = Instantiate(droneButtonPrefab, selectionContent.transform);
        droneButton.GetComponentInChildren<TextMeshProUGUI>().text = drone.name; 
        droneButton.onClick.AddListener(() => { SelectByClick.SelectDrone(drone); });
        drone.GetComponent<SelectionIndication>().selectionButton = droneButton.GetComponent<SelectionButton>();
    }
}
