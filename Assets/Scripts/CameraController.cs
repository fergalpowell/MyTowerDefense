using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    private string turretTag = "Turret";
    private Vector3 turretViewPos;
    private Quaternion turretViewRot;
    private Vector3 originalViewPos;
    private Vector3 originalViewRot;
    Camera mainCam;
    Camera startCamera;
    GameObject[] turrets;
    private int i;
    private bool showTurretCam = false;
    private GameObject nextButton;
    private GameObject previousButton;

    private void Start()
    {
        i = 0;
        mainCam = Camera.main;
        originalViewPos = new Vector3(35f, 80f, 14f);
        originalViewRot = new Vector3(75f, 0f, 0f);
        nextButton = GameObject.FindGameObjectWithTag("NextTurret");
        previousButton = GameObject.FindGameObjectWithTag("PreviousTurret");
    }
    
    public void ShowTurretCam()
    {
        showTurretCam = !showTurretCam;
    }

    public void NextTurret()
    {
        if (i < turrets.Length - 1)
        {
            i++;
        }
    }

    public void PreviousTurret()
    {
        if (i != 0)
        {
            i--;
        }
    }

    // Update is called once per frame
    void Update () {

        turrets = (GameObject[])GameObject.FindGameObjectsWithTag(turretTag);

        if (showTurretCam && turrets.Length > 0)
        {
            nextButton.SetActive(true);
            previousButton.SetActive(true);
            if (turrets[i].name == "StandardTurret")
            {
                turretViewPos = turrets[i].transform.position;
                turretViewRot = turrets[i].transform.Find("PartToRotate").rotation;
                turretViewPos.y += 2f;
            }
            else
            {
                turretViewPos = turrets[i].transform.position;
                turretViewRot = turrets[i].transform.Find("PartToRotate").rotation;
                turretViewPos.y += 2.5f;
            }
                
            mainCam.transform.position = turretViewPos;
            mainCam.transform.rotation = turretViewRot;
        }
        else if (showTurretCam == false || turrets == null)
        {
            showTurretCam = false;
            mainCam.transform.position = originalViewPos;
            mainCam.transform.rotation = Quaternion.Euler(originalViewRot);
            if (nextButton != null && previousButton != null)
            {
                nextButton.SetActive(false);
                previousButton.SetActive(false);
            }
        }
        else
        {
            showTurretCam = false;
        }
	}
}
