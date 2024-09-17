using UnityEngine;

public enum StatToChange
{
    None,
    Health,
    Mana,
    Weapon
}

public enum PowerToChange
{
    None,
    Strenght,
    Speed,
    Health
}

[CreateAssetMenu(menuName = "Items")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    
    public Sprite sprite;
    public int amount;
    
    public string itemDescription;
    
    public StatToChange statToChange;
    public string statAmount;
    
    public PowerToChange powerUp;
    public string powerUpAmount;

    public bool Useitem()
    {
        switch (statToChange)
        {   
            case StatToChange.Health:
                Debug.Log("Je krijgt hp terug of er komt meer?");
                return true;
            case StatToChange.Mana:
                Debug.Log("Hier komt een boost");
                break;
            default:
                break;
        }

        return false;
    }
    
}
