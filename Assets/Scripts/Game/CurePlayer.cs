using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurePlayer 
{
    private Health _hP;
    private Armour _armour;
    private Animate _animate;

    public CurePlayer(Health HP, Armour armour , Animate animate  )
    {
        _hP = HP;
        _armour = armour;
        _animate = animate;
    }

    public void HealPlayer()
    {
        _hP._currentHealth = 100;
        _armour._currentArmour = 100;
        _animate.ActiveAnimator();
    }
}
