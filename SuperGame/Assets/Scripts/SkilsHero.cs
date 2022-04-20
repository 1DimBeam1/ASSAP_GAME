using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilsHero : MonoBehaviour
{
    public Transform attakPoint;
    public float attakRange = 0.5f;
    public LayerMask enemyLayers;

    public int swordDM = 20;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
          Attak();
        }
    }

    void Attak()
    {
        Collider2D[] hitEnemise  = Physics2D.OverlapCircleAll(attakPoint.position, attakRange , enemyLayers);

        foreach (Collider2D enemy in hitEnemise)
        {
            enemy.GetComponent<EnemyCondition>().TakeDamage(swordDM);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attakPoint == null)
            return;
        Gizmos.DrawWireSphere(attakPoint.position, attakRange);
    }
}
