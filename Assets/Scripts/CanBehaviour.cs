using UnityEngine;

public class CanBehaviour : Enemy
{
    public float curSpeed;
    public Vector3 lastVelocity;
    public Rigidbody myRB;
    public Vector3 direction;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        lastVelocity = myRB.velocity;
    }

    void ChangeDirection()
    {
        Debug.Log("cambiar");

        curSpeed = lastVelocity.magnitude;
        direction = myPlayerTransform.forward;

        myRB.velocity = direction * Mathf.Max(curSpeed, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("DamageZone"))
        {
            ChangeDirection();
        }

        else if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myDamageController.StartDamageEvent();
            Destroy(gameObject);
        }

        else Destroy(gameObject);
    }
}
