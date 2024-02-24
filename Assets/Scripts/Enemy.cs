using UnityEngine;

public class Enemy : Entity
{
    private void Start()
    {
        life = 5;
        myDamageController.DoDamage += TakeDamage;
    }
    void TakeDamage()
    {
        if (life <= 1) Destroy(gameObject);
        else
        {
            Debug.Log("Hacer daño a enemigo");
            life--;
        }
    }

    private void OnDisable()
    {
        myDamageController.DoDamage -= TakeDamage;
    }
}
