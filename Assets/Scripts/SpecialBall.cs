using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBall : MonoBehaviour
{
    public int bounceTimes;

    public Rigidbody myRB;
    private Vector3 direction;
    private Vector3 lastVelocity;
    private float curSpeed;

    private void LateUpdate()
    {
        lastVelocity = myRB.velocity;
        if (bounceTimes <= 0) if (gameObject != null) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            curSpeed = lastVelocity.magnitude;
            direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            myRB.velocity = direction * Mathf.Max(curSpeed, 0);

            Debug.Log("Bounce");
            bounceTimes--;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
