using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int damage;
    
    public int Health { 
        get { return health; } 
        set {
            OnHpLoss();
            health -= value; 
        }
    }

    public int Damage
    {
        get { return damage; }
        set { damage += value; }
    }

    public virtual void OnHpLoss()
    {

    }
}
