using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private int health;
    private int damage;
    
    public int Health { 
        get { return health; } 
        set { health -= value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage += value; }
    }
}
