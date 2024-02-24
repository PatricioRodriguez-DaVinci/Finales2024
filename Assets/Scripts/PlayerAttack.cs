using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour
{
    public InputController myInputs;

    public GameObject[] attackCollider;
    public List<bool> isAttackActive = new List<bool>();

    [SerializeField] int actualAttack = 0;

    [SerializeField] float desactivationTime = 0.1f;
    [SerializeField] float comboTimer = 0f;
    [SerializeField] float comboSetTimer = 0.5f;

    private void Start()
    {
        for (int i = 0; i < isAttackActive.Count; i++)
        {
            attackCollider[i].SetActive(false);
            isAttackActive[i] = false;
        }
    }

    private void FixedUpdate()
    {
        if (comboTimer > 0) comboTimer -= 1 * Time.deltaTime;
        else actualAttack = 0;
    }

    void Update()
    {
        if (myInputs.isAttacking)
        {
            attackCollider[actualAttack].SetActive(true);

            Invoke("DeactivateObject", desactivationTime);

            if (actualAttack < isAttackActive.Count - 1)
            {
                actualAttack++;
                comboTimer = comboSetTimer;
            }

            else
            {
                actualAttack = 0;
                comboTimer = 0.05f;
            }
        }
    }

    void DeactivateObject()
    {
        if (actualAttack != 0) attackCollider[actualAttack -1].SetActive(false);
        else attackCollider[isAttackActive.Count - 1].SetActive(false);
    }
}
