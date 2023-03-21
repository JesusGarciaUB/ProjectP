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

    public int HealthEqualizer
    {
        set { 
            health = value;
            if (health < 6) GlobalVariables.Instance.player.GetComponent<PlayerBase>().anim.SetTrigger("low");
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
