using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroCondition : MonoBehaviour
{
    Animator anim;

    public int ST = 100;
    public int curST;

    public int HP = 100;
    public int curHP;

    private void Start()
    {
        curHP = HP;
        curST = ST;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Tired();
        Recovery();
        ExitGame();    
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
        anim.StopPlayback();
        anim.Play("Died");
        GetComponent<Hero>().enabled = false;
        GetComponent<SkilsHero>().enabled = false;

        Invoke("Respawn",3f);
    }

    void Respawn()
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
                curST += 10;
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

    void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene (1);
        }
    }
}
