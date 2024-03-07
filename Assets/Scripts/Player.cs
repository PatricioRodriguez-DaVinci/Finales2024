using TMPro;
using UnityEngine;

public class Player : Entity
{
    public TMP_Text livesText;
    public int cheatLives;
    public int lives;
    private void Start()
    {
        myDamageController.DoTakeDamage += TakeDamage;
        lives = 15;
        cheatLives = 99;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GainLife();
        }
        livesText.text = lives.ToString();

        Debug.Log(lives);
    }

    public void GainLife()
    {
        lives++;
    }

        public void TakeDamage()
    {
        if (lives > 1)
        {
            lives--;
        }

        else if (lives <= 1)
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
        myScenesController.LoadScene(MyScene.GameOver);
    }
}
