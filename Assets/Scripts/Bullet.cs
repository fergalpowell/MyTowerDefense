using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        if (target.gameObject.GetComponent<Enemy>().state.ToString() == "FullShield")
        {
            target.gameObject.GetComponent<Enemy>().state = Enemy.States.HalfShield;
        }
        else if (target.gameObject.GetComponent<Enemy>().state.ToString() == "HalfShield")
        {
            target.gameObject.GetComponent<Enemy>().state = Enemy.States.BasicShield;
        }
        else if (target.gameObject.GetComponent<Enemy>().state.ToString() == "BasicShield")
        {
            target.gameObject.GetComponent<Enemy>().state = Enemy.States.Healthy;
        }
        else if (target.gameObject.GetComponent<Enemy>().state.ToString() == "Healthy")
        {
            target.gameObject.GetComponent<Enemy>().state = Enemy.States.Sick;
        }
        else if (target.gameObject.GetComponent<Enemy>().state.ToString() == "Sick")
        {
            target.gameObject.GetComponent<Enemy>().state = Enemy.States.Dying;
        }
        else if (target.gameObject.GetComponent<Enemy>().state.ToString() == "Dying")
        {
            target.gameObject.GetComponent<Enemy>().state = Enemy.States.Dying;
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 5f);
            Destroy(target.gameObject);
            PlayerStats.Money += PlayerStats.reward;
        }
    }
}
