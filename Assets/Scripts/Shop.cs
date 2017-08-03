using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TurretInfo standardTurret;
    public TurretInfo rocketTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectRocketTurret()
    {
        buildManager.SelectTurretToBuild(rocketTurret);
    }

    public void SelectLandMine()
    {
        buildManager.SelectLandMineToBuild(buildManager.landminePrefab);
    }
}
