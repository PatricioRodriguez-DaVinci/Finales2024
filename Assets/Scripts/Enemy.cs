using UnityEngine;

public class Enemy : Entity
{
    public TimeController myTimeController;

    private void Start()
    {
        _go = GameObject.FindGameObjectWithTag("Controllers");
        if (_go != null) myTimeController = _go.GetComponent<TimeController>();
    }

    protected virtual void CheckTime()
    {
        if (myTimeController.timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void TakeDamage()
    {
        if (life <= 1) Destroy(gameObject);
        else
        {
            Debug.Log("Hacer danio a enemigo");
            life--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DamageZone") || other.gameObject.layer == LayerMask.NameToLayer("BallZone"))
        {
            TakeDamage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageZone") || collision.gameObject.layer == LayerMask.NameToLayer("BallZone"))
        {
            TakeDamage();
        }
    }
}
