using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCondition : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP;
    public Transform point;
    void Start()
    {
        curHP = maxHP;
    }

    public void TakeDamage(int damge)
    {
        curHP -= damge;

        if (curHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
         Destroy(gameObject);
    }
}
