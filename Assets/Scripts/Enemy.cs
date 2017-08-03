using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    public Transform target;
    public int index = 0;
    private Quaternion rot = new Quaternion(0, 90, 0, 0);
    public static int min;
    public static int max;
    
    private Renderer rend;
    public Color healthyColor;
    public Color sickColor;
    public Color dyingColor;
    public Color FullShieldColor;
    public Color HalfShieldColor;
    public Color BasicShieldColor;

    public enum States
    {
        FullShield,
        HalfShield,
        BasicShield,
        Healthy,
        Sick,
        Dying
    }

    private States _state;

    public States state
    {
        get { return _state; }
        set
        {
            _state = value;
            EnterState(_state);
        }
    }

    public void EnterState(States state)
    {
        switch (state)
        {
            case States.FullShield:
                rend.material.color = FullShieldColor;
                break;
            case States.HalfShield:
                rend.material.color = HalfShieldColor;
                break;
            case States.BasicShield:
                rend.material.color = BasicShieldColor;
                break;
            case States.Healthy:
                rend.material.color = healthyColor;
                break;
            case States.Sick:
                rend.material.color = sickColor;
                break;
            case States.Dying:
                rend.material.color = dyingColor;
                break;
            default:
                break;
        }
    }

    void Start()
    {
        target = Waypoints.points[index];
        rend = gameObject.GetComponentInChildren<Renderer>();
        WaveSpawner wave = new WaveSpawner();
 
        int startState = Random.Range(min, max);
        switch (startState)
        {
            case 1:
                state = States.Healthy;
                break;
            case 2:
                state = States.BasicShield;
                break;
            case 3:
                state = States.HalfShield;
                break;
            case 4:
                state = States.FullShield;
                break;
            case 5:
                state = States.Healthy;
                break;
            default:
                state = States.Healthy;
                break;
        }
        
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        switch (index)
        {
            case 1:
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    break;
                }
            case 2:
                {
                    transform.localEulerAngles = new Vector3(0, -90, 0);
                    break;
                }
            case 3:
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    break;
                }
            case 4:
                {
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    break;
                }
            case 5:
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    break;
                }
            case 6:
                {
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    break;
                }
            case 7:
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    break;
                }
            case 8:
                {
                    transform.localEulerAngles = new Vector3(0, -90, 0);
                    break;
                }
            case 9:
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    break;
                }
            case 10:
                {
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    break;
                }
            case 11:
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    break;
                }
            case 12:
                {
                    transform.localEulerAngles = new Vector3(0, 90, 0);
                    break;
                }
            case 13:
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                    break;
                }
            default:
                break;
        }
        if (index == 1)
        {
            
        }
        if (index ==2 )
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }


        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            UpdateWaypoints();
        }
    }

    void UpdateWaypoints()
    {
        if (index >= Waypoints.points.Length -1)
        {
            EndPath();
            return;
        }

        index++;
        target = Waypoints.points[index];
    }

    void EndPath()
    {
        Destroy(gameObject);
        if (PlayerStats.lives > 0)
        {
            PlayerStats.lives--;
        }
        else
        {
            GameObject gameOver = GameObject.FindGameObjectWithTag("Canvas");
            gameOver.GetComponent<UIManager>().showGameOver();
        }
    }
}
