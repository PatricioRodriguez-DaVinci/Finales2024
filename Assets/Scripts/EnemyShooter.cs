using UnityEngine;

public class EnemyShooter : Enemy
{
    [Header("---------- Ranges ----------\n")]
    [SerializeField] private float shootRange;
    [SerializeField] private float minDistance;
    [SerializeField] private float viewRange;

    [Header("---------- Shoot ----------\n")]
    [SerializeField] protected GameObject shootingPrefab;
    [SerializeField] protected GameObject spawnPoint;
    [SerializeField] protected float shootForce;

    protected float _reloadingTime;
    [SerializeField] protected float newReloadingTime;

    void Update()
    {
        var distance = Vector3.Distance(transform.position, myPlayerTransform.position);
        _reloadingTime -= 1 * Time.deltaTime;

        if (distance >= minDistance && distance < viewRange)
        {
            LookAtPlater();
        }

        if (Vector3.Distance(transform.position, myPlayerTransform.position) <= shootRange && _reloadingTime <= 0)
        {
            Shoot();
        }
    }
    protected virtual void Shoot()
    {
        GameObject myInstance = GameObject.Instantiate(shootingPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        myInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootForce);
    }

    protected virtual void LookAtPlater()
    {
        transform.LookAt(myPlayerTransform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}