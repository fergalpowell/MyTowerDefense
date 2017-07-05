using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    private GameObject landMine;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        GameObject landMineToBuild = BuildManager.instance.getlandMineToBuild();
        var mousePos = Input.mousePosition;
        Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        landMine = GameObject.Instantiate(landMineToBuild, transform.position, transform.rotation);
    }
}