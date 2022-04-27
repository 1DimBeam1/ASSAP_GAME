using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilsHero : MonoBehaviour
{
    Animator anim;

    public Transform attakPoint;
    public Transform rangeAtPoint;
    public float attakRange = 0.5f;
    public float attakRangeTree = 0.5f;
    public LayerMask enemyLayers;

    public int swordDM = 20;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
         Attak();
         TreeAttak();
    }

    bool attakOn = true;
    void Attak()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && attakOn)
        {
            anim.StopPlayback();
            anim.Play("StandartAttak");

            Collider2D hitEnemise = Physics2D.OverlapCircle(attakPoint.position, attakRange, enemyLayers);
            if (hitEnemise != null)
                hitEnemise.GetComponent<EnemyCondition>().TakeDamage(swordDM);
            attakOn = false;
            Invoke("Att",0.4f); 
        }
    }
    void Att()
    {
        attakOn = true;
    }

    void TreeAttak()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && !GetComponent<HeroCondition>().tired)
        {

            anim.StopPlayback();
            anim.Play("TreeAttak");

            Collider2D hitEnemise = Physics2D.OverlapCircle(rangeAtPoint.position, attakRangeTree, enemyLayers);

            if (hitEnemise != null)
                hitEnemise.GetComponent<EnemyCondition>().TakeDamage(swordDM);

            GetComponent<HeroCondition>().GetTired(10);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attakPoint == null || rangeAtPoint == null)
            return;
        Gizmos.DrawWireSphere(attakPoint.position, attakRange);
        Gizmos.DrawWireSphere(rangeAtPoint.position, attakRangeTree);
    }
}
