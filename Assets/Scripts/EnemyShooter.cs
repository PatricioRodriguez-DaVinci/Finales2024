using UnityEngine;

public class EnemyShooter : Enemy
{
    [Header("---------- Ranges ----------\n")]
    [SerializeField] private float shootRange;
    [SerializeField] private float minDistance;
    [SerializeField] private float viewRange;

    [Header("---------- Shoot ----------\n")]
    [SerializeField] private GameObject canPrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float shootForce;

    private float _reloadingTime;

    void Update()
    {
        var distance = Vector3.Distance(transform.position, myPlayerTransform.position);
        _reloadingTime -= 1 * Time.deltaTime;

        if (distance >= minDistance && distance < viewRange)
        {
            transform.LookAt(myPlayerTransform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, myPlayerTransform.position) <= shootRange && _reloadingTime <= 0)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject myInstance = GameObject.Instantiate(canPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        myInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootForce);

        _reloadingTime = 3f;
    }
}