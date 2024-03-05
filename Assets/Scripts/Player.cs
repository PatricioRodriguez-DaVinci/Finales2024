using TMPro;
using UnityEngine;

public class Player : Entity
{
    public TMP_Text livesText;
    private void Start()
    {
        myDamageController.DoTakeDamage += TakeDamage;
        life = 9;
        livesText.text = life.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            life = 99;
            livesText.text = life.ToString();
        }
    }

    public void GainLife()
    {
        life++;
        livesText.text = life.ToString();
    }

        public void TakeDamage()
    {
        if (life > 1)
        {
            Debug.Log("Hacer daño a Player");
            life--;
            livesText.text = life.ToString();
        }

        else
        {
            Debug.Log("Esperar 1 y cargar escena perdiste");
            Invoke("DestroyMe", 3);
            livesText.text = "Game Over";
            gameObject.SetActive(false);
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
