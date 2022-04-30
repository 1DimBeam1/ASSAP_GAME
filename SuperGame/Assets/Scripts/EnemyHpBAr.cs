using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBAr : MonoBehaviour
{
    public Slider slider;
    public EnemyCondition enemy;

    void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    void setHealth(int health)
    {

        slider.value = health;
    }
    void Start()
    {
        setMaxHealth(enemy.maxHP);
    }

    void Update()
    {
        setHealth(enemy.curHP);
    }
}
