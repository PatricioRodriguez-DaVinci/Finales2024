using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    private void Start()
    {
        life = 5;
        myDamageController.DoTakeDamage += TakeDamage;
    }
    public void TakeDamage()
    {
        if (life <= 1)
        {
            Debug.Log("Esperar 3 y cargar escena perdiste");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Hacer daño a Player");
            life--;
        }
    }

    private void OnDisable()
    {
        myDamageController.DoTakeDamage -= TakeDamage;
    }
}
