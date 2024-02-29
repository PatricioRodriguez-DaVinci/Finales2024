using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
    [SerializeField] private float minDistance;
    [SerializeField] private float viewRange;

    void Update()
    {
        var distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance >= minDistance && distance < viewRange)
        {
            transform.LookAt(playerTransform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
