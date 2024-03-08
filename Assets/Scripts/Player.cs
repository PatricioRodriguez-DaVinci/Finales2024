using TMPro;
using UnityEngine;

public class Player : Entity
{
    public TMP_Text livesText;
    public int cheatLives;
    public int lives;

    [SerializeField] protected AudioClip _receiveDamageClip;
    [SerializeField] protected AudioClip _playerDeadClip;

    public GameObject deadPrefab;
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
    }

    public void GainLife()
    {
        lives++;
    }

        public void TakeDamage()
    {
        if (lives > 1)
        {
            SFXManager.Instance.PlaySFX(_receiveDamageClip);
            lives--;
        }

        else if (lives <= 1)
        {
            SFXManager.Instance.PlaySFX(_playerDeadClip);
            Invoke("DestroyMe", 2);
            livesText.text = "Game Over";
            GameObject myInstance = GameObject.Instantiate(deadPrefab, transform.position, Quaternion.identity) as GameObject;
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
