using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    Rigidbody2D phys;
    public Transform player;

    public float speed;
    public float agroDist;

    private void Start()
    {
        phys = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Hunt();
    }

    void Hunt()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDist)
        {
            if (player.position.x < transform.position.x)
            {
                phys.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else 
            { 
                phys.velocity = new Vector2(speed, 0);
                transform.localScale = new Vector2(-1, 1);
            };

        }
        else
        {
            phys.velocity *= new Vector2(0, 0);
        }
    }

    public int damage = 50;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.name == "Hero")
        {
            other.GetComponent<HeroCondition>().TakeDamage(damage);
        }
    }

}
