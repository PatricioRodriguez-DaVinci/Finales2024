using UnityEngine;
public class EnemyBoss : MonoBehaviour
{
    private GameObject _go;
    private ScenesController myScenesController;

    [SerializeField] protected int bossLife = default;

    private void Start()
    {
        _go = GameObject.FindGameObjectWithTag("Controllers");
        if (_go != null) myScenesController = _go.GetComponent<ScenesController>();
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
    private void TakeDamage()
    {
        if (bossLife <= 1)
        {
            Invoke("DestroyMe", 1f);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hacer danio a boss");
            bossLife--;
        }
    }

    private void DestroyMe()
    {
        myScenesController.LoadScene("Win");
    }
}
