using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    private string turretTag = "StandardTurret";
    private Vector3 turretViewPos;
    private Quaternion turretViewRot;
    private Vector3 originalViewPos;
    private Vector3 originalViewRot;
    Camera mainCam;
    Camera startCamera;
    GameObject[] turrets;
    private int i;
    private bool showTurretCam = false;

    private void Start()
    {
        i = 0;
        mainCam = Camera.main;
        originalViewPos = new Vector3(35f, 80f, 14f);
        originalViewRot = new Vector3(75f, 0f, 0f);
    }
    

    // Update is called once per frame
    void Update () {

        turrets = (GameObject[])GameObject.FindGameObjectsWithTag(turretTag);
        
        

        if ((turrets != null && Input.GetKey("w")) || showTurretCam)
        {
            showTurretCam = true;
            if(Input.GetKey("e"))
            {
                if (i < turrets.Length - 1)
                {
                    i++;
                }
            }
            if (Input.GetKey("r"))
            {
                if (i > 0)
                {
                    i--;
                }
            }
            if (turrets != null)
            {
                turretViewPos = turrets[i].transform.position;
                turretViewRot = turrets[i].transform.FindChild("PartToRotate").rotation;
                turretViewPos.y += 2f;
            }
            
            mainCam.transform.position = turretViewPos;
            mainCam.transform.rotation = turretViewRot;
        }
            
        if (Input.GetKey("q"))
        {
            showTurretCam = false;
            mainCam.transform.position = originalViewPos;
            mainCam.transform.rotation = Quaternion.Euler(originalViewRot);
        }
	}
}
