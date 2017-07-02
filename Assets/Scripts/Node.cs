using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color startColor;

    public Vector3 positionOffset;
    private Renderer rend;

    private GameObject turret;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
	}

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cannot build here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = GameObject.Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

}
