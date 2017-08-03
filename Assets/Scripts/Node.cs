using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Color startColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;
    private Renderer rend;

    public GameObject turret;

    BuildManager buildManager;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney )
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = Color.red;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Cannot build here");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

}
