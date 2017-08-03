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
    public GameObject rocketTurretPrefab;
    public GameObject landminePrefab;    

    private TurretInfo turretToBuild;

    private GameObject landMineToBuild;

    public GameObject getlandMineToBuild()
    {
        return landMineToBuild;
    }

    // properties to check if there is already a turret built and the player has enough money
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretInfo turret)
    {
        turretToBuild = turret;
    }

    public void SelectLandMineToBuild(GameObject landmine)
    {
        landMineToBuild = landmine;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough moeny");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret =  (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        BuildManager.instance.SelectTurretToBuild(null);
    }
}
