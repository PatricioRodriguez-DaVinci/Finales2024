using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : EnemyShooter
{
    [SerializeField] private float aimRotation;
    override protected void LookAtPlater()
    {
        // Se deja vacío a drede para que no haga nada
    }

    protected override void CheckTime()
    {
        // Se deja vacío a drede para que no haga nada
    }
    override protected void Shoot()
    {
        GameObject myInstance = GameObject.Instantiate(shootingPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        myInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootForce);
        spawnPoint.transform.Rotate(Vector3.up, aimRotation);

        _reloadingTime = newReloadingTime;
    }
}
