using UnityEngine;

public class DamageController : MonoBehaviour
{
    public delegate void MyDelegate();
    public event MyDelegate DoTakeDamage;

    public void StartDamageEvent()
    {
        DoTakeDamage();
    }
}
