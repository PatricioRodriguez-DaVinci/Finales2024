using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
    [SerializeField] private float minDistance;
    [SerializeField] private float viewRange;

    public float impulseForce = 100f;



    void Update()
    {
        CheckTime();

        var distance = Vector3.Distance(transform.position, myPlayerTransform.position);

        if (distance >= minDistance && distance < viewRange)
        {
            transform.LookAt(myPlayerTransform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myDamageController.StartDamageEvent();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageZone"))
        {
            rb.AddForce(-transform.forward * impulseForce, ForceMode.Impulse);
            TakeDamage();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("BallZone"))
        {
            rb.AddForce(-transform.forward * impulseForce / 2, ForceMode.Impulse);
            TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (other.gameObject.layer == LayerMask.NameToLayer("DamageZone"))
        {
            rb.AddForce(-transform.forward * impulseForce, ForceMode.Impulse);
            TakeDamage();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("BallZone"))
        {
            rb.AddForce(-transform.forward * impulseForce / 2, ForceMode.Impulse);
            TakeDamage();
        }
    }
}
