using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    private GameObject landMine;
    BuildManager buildManager;

    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (buildManager.getlandMineToBuild() == null || PlayerStats.Money < 250)
        {
            return;
        }
        GameObject landMineToBuild = BuildManager.instance.getlandMineToBuild();
        Vector3 landminePos = transform.position;
        landminePos.y = 0;
        landMine = GameObject.Instantiate(landMineToBuild, landminePos, transform.rotation);
        PlayerStats.Money -= 250;
        BuildManager.instance.SelectLandMineToBuild(null);
    }
}