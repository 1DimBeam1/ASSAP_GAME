using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroCondition : MonoBehaviour
{
    public int HP = 100;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
