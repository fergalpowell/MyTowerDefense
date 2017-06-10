using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    public Transform target;
    public int index = 0;

    void Start()
    {
        target = Waypoints.points[index];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            UpdateWaypoints();
        }
    }

    void UpdateWaypoints()
    {
        if (index >= Waypoints.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        index++;
        target = Waypoints.points[index];
    }
}
