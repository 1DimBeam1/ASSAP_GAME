using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilsHero : MonoBehaviour
{
    Animator anim;

    public Transform attakPoint;
    public Transform rangeAtPoint;
    public float attakRange = 0.5f;
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

    bool justAttak;
    void Attak()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            justAttak = true;
            anim.SetBool("attakON", justAttak);
            Collider2D hitEnemise = Physics2D.OverlapCircle(attakPoint.position, attakRange, enemyLayers);
            if (hitEnemise != null)
                hitEnemise.GetComponent<EnemyCondition>().TakeDamage(swordDM);
        }
        else
        {
            justAttak = false;
            anim.SetBool("attakON", justAttak);
        }
    }

    bool treeAt ;
    void TreeAttak()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            treeAt = true;
            anim.SetBool("TreeAttak", treeAt);
            Collider2D hitEnemise = Physics2D.OverlapCircle(rangeAtPoint.position, attakRange, enemyLayers);

            if (hitEnemise != null)
                hitEnemise.GetComponent<EnemyCondition>().TakeDamage(swordDM);

        }
        else
        {
            treeAt = false;
            anim.SetBool("TreeAttak", treeAt);
        }     
        

        
    }
    private void OnDrawGizmosSelected()
    {
        if (attakPoint == null || rangeAtPoint == null)
            return;
        Gizmos.DrawWireSphere(attakPoint.position, attakRange);
        Gizmos.DrawWireSphere(rangeAtPoint.position, attakRange);
    }
}
