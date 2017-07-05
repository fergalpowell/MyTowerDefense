using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one build");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject landminePrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
        landMineToBuild = landminePrefab;
    }

    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    private GameObject landMineToBuild;

    public GameObject getlandMineToBuild()
    {
        return landMineToBuild;
    }
}
