using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatToChange
{
    none,
    Health,
    Mana,
    Weapon
}

public enum PowerToChange
{
    none,
    Strenght,
    Speed,
    Health
}

[CreateAssetMenu(menuName = "Items")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    
    public StatToChange statToChange;
    public string statAmount;
    
    public PowerToChange powerUp;
    public string powerUpAmount;

    public void Useitem()
    {
        switch (statToChange)
        {   
            case StatToChange.Health:
                Debug.Log("Je krijgt hp terug of er komt meer?");
                break;
            case StatToChange.Mana:
                Debug.Log("Hier komt een boost");
                break;
            default:
                break;
        }
    }
}
