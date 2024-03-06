using UnityEngine;
using System.Collections.Generic;
public class EnemyBoss : MonoBehaviour
{
    private GameObject _go;
    private ScenesController myScenesController;

    [SerializeField] protected int bossLife = default;

    private void Start()
    {
        _go = GameObject.FindGameObjectWithTag("Controllers");
        if (_go != null) myScenesController = _go.GetComponent<ScenesController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DamageZone"))
        {
            TakeDamage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageZone"))
        {
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        if (bossLife <= 1)
        {
            Invoke("DestroyMe", 1f);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hacer danio a boss");
            bossLife--;
        }
    }

    private void DestroyMe()
    {
        myScenesController.LoadScene("Win");
    }

    public List<Transform> waypoints;
    public float speed = 5f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Check if there are any waypoints
        if (waypoints.Count == 0)
            return;

        // Move towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the GameObject has reached the current waypoint
        if (transform.position == targetWaypoint.position)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}
