using UnityEngine;

public class Enemy : Entity
{
    void TakeDamage()
    {
        if (life <= 1) Destroy(gameObject);
        else
        {
            Debug.Log("Hacer daño a enemigo");
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
}
