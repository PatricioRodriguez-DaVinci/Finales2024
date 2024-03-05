using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
    [SerializeField] private float minDistance;
    [SerializeField] private float viewRange;

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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myDamageController.StartDamageEvent();
        }
    }
}
