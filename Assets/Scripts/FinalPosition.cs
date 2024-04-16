using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPosition : MonoBehaviour
{
    [SerializeField] private List<Transform> drillFinalPositions = new List<Transform>();
    [SerializeField] private List<Transform> APCFinalPositions = new List<Transform>();
    [SerializeField] private Transform kamikazeFinalPosition;
    private int freeDrillPosition = 0;
    private int freeAPCPosition = 0;

    public Transform SelectPosition(string type)
    {
        Transform selectedPosition;
        if (type == "Drill")
        {
            selectedPosition = drillFinalPositions[freeDrillPosition];
            freeDrillPosition++;
            return selectedPosition;
        }
        else if (type == "APC")
        {
            selectedPosition = APCFinalPositions[freeAPCPosition];
            freeAPCPosition++;
            return selectedPosition;
        }
        else if (type == "Kamikaze")
        {
            return kamikazeFinalPosition;
        }
        else return null;
    }

    public void RecetPositions()
    {
        freeDrillPosition = 0;
        freeAPCPosition = 0;
    }
}

