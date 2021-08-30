using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int arrowDamage = 100;
    int projectileDamage;
    PlayerStats stats;
    EnemyNew dmg;

    void Start()
    {
        dmg = FindObjectOfType<EnemyNew>();
        stats = PlayerStats.instance;
        if (SaveGame.HaveASaveDamage() == true)
        {
            arrowDamage = stats.attackDamage;
        }
        else
        {
            arrowDamage = 100;
        }        
    }
    public int GetArrowDamage()
    {
        return arrowDamage;
    }

    public int GetProjectileDamage()
    {
        return dmg.projectiledmg;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
