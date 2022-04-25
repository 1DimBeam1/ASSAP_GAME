using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider slider;
    public HeroCondition playerHP;

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
        setMaxHealth(playerHP.HP);
    }

    void Update()
    {
        setHealth(playerHP.curHP);
    }
}
