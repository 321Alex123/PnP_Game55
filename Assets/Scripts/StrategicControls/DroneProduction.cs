using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DroneProduction : MonoBehaviour
{
    [SerializeField] private Recources playerBaseWallet;

    public int kamikadzePrice = 2;
    public int APPrice = 5;
    public int EMPPrice = 7;

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
        int dronePrice = GetDronePrice(dronePrefab);

        if (playerBaseWallet.HasEnoughScrap(dronePrice))
        {
            GameObject drone = Instantiate(dronePrefab, droneSpawn.position, droneSpawn.rotation);
            CreateDroneButton(drone);
            drone.GetComponent<Moving>().MoveToPosition(droneGathering.position);

            playerBaseWallet.SpendScrap(dronePrice);
        }
        else
        {

        }
    }

    private int GetDronePrice(GameObject dronePrefab)
    {
        if (dronePrefab == kamikazeDronePrefab)
        {
            return kamikadzePrice;
        }

        if (dronePrefab == APDronePrefab)
        {
            return APPrice;
        }

        if (dronePrefab == EMPDronePrefab)
        {
            return EMPPrice;
        }

        return 0;
    }

    private void CreateDroneButton(GameObject drone)
    {
        Button droneButton = Instantiate(droneButtonPrefab, selectionContent.transform);
        droneButton.GetComponentInChildren<TextMeshProUGUI>().text = drone.name;
        droneButton.onClick.AddListener(() => { SelectByClick.SelectDrone(drone); });
        drone.GetComponent<SelectionIndication>().selectionButton = droneButton.GetComponent<SelectionButton>();
    }
}
