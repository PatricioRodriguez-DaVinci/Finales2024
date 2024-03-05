using UnityEngine;

public class Enemy : Entity
{
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
}
