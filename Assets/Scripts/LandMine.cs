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

    private IEnumerator OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            Debug.Log("Explosion");
            explosionPrefab.SetActive(true);
            Destroy(col.gameObject);
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
            
        }
    }
}
