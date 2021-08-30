using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public int maxHealt = 100;
    int currentHealt;
    public int attackDamage = 100;
    public int maxArrow = 1;
    public float healtRegenRate = 2f;
    public float movementSpeed = 4f;
    
    void Start()
    {
        if (SaveGame.HaveASaveDamage() == true)
        {
            attackDamage = SaveGame.ReadAttackDamage();
        }
        else
        {
            attackDamage = 100;
        }
        if (SaveGame.HaveASaveMovement() == true)
        {
            movementSpeed = SaveGame.ReadMovementSpeed();
        }
        else
        {
            movementSpeed = 4f;
        }
        if (SaveGame.HaveASaveHealt() == true)
        {
            maxHealt = SaveGame.ReadHealt();
        }
        else
        {
            maxHealt = 100;
        }
        if (SaveGame.HaveASaveArrow() == true)
        {
            maxArrow = SaveGame.ReadNumberOfArrows();
        }
        else
        {
            maxArrow = 1;
        }
    }
    public int curHealt
    {
        get { return currentHealt; }
        set { currentHealt = Mathf.Clamp(value, 0, maxHealt); }
    }    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
