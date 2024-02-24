using UnityEngine;

public class DamageController : MonoBehaviour
{
    public delegate void MyDelegate();
    public event MyDelegate DoDamage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DoDamage != null)
        {
            DoDamage();
        }
    }
}
