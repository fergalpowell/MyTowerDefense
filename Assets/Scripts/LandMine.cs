using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour {

    public GameObject explosionPrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(this.gameObject);
            GameObject effectIns = (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(effectIns, 5f);
            Destroy(col.gameObject);
            PlayerStats.Money += PlayerStats.reward;
        }         
    }
}
