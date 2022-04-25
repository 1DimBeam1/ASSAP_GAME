using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STbar : MonoBehaviour
{
    public Slider slider;
    public HeroCondition playerST;

    void setMaxST(int st)
    {
        slider.maxValue = st;
        slider.value = st;
    }

    void setST(int st)
    {
        slider.value = st;
    }
    void Start()
    {
        setMaxST(playerST.ST);
    }

    void Update()
    {
        setST(playerST.curST);
    }
}
