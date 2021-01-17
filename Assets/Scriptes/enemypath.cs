using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypath : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] waveconfig waveConfig;
     List<Transform> waypoint;
    int waypointindex = 0;
    void Start()
    {
        waypoint = waveConfig.GetWayPoints();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (waypointindex <= waypoint.Count - 1)
        {
            var targetPosition = waypoint[waypointindex].transform.position;
            var movementthisframe = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementthisframe);
            if (transform.position == targetPosition)
            {
                waypointindex += 1;
                Debug.Log("Run");
            }
        }
        else
        {
            Debug.Log("End");
            Destroy(gameObject);
        }
        }
    }
