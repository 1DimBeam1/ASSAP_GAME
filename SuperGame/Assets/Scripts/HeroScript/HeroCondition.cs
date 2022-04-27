using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroCondition : MonoBehaviour
{
    public int ST = 100;
    public int curST;

    public int HP = 100;
    public int curHP;

    private void Start()
    {
        curHP = HP;
        curST = ST;
    }
    private void Update()
    {
        Tired();
        Recovery();
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if (curHP <= 0)
        {
            Die();
        }
    }

    public void GetTired(int tir)
    {
        curST -= tir;
    }
    void Die()
    {

        SceneManager.LoadScene(1);
    }

    float delTm =0;
    void Recovery()
    {
        if (tired)
        {
            delTm += Time.deltaTime;
            if (delTm >= 0.5f)
            {
                curST += 5;
                delTm = 0;
            }
        }
    }
    public bool tired;
     void Tired()
    {
        if (curST <= 0)
        {
            tired = true;
        }
        else if (curST >= ST) { tired = false; }
    }
}
