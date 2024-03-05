using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public TMP_Text livesText;
    private void Start()
    {
        life = 5;
        myDamageController.DoTakeDamage += TakeDamage;
        livesText.text = life.ToString();
    }
    public void TakeDamage()
    {
        if (life <= 1)
        {
            Debug.Log("Esperar 1 y cargar escena perdiste");
            Invoke("DestroyMe", 1);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hacer daño a Player");
            life--;
            livesText.text = life.ToString();
        }
    }

    private void OnDisable()
    {
        myDamageController.DoTakeDamage -= TakeDamage;
    }

    private void DestroyMe()
    {
        myScenesController.LoadScene("GameOver");
    }
}
