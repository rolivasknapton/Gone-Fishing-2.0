using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword, 
        Cube,
        HealthPotion,
        ManaPotion,
        Coin,
        Medkit,
        Fish,
        Hand,
        Key,
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Cube: return ItemAssets.Instance.cubeSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion: return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Fish: return ItemAssets.Instance.fishSprite;
            case ItemType.Hand: return ItemAssets.Instance.handSprite;
            case ItemType.Key: return ItemAssets.Instance.keySprite;
        }
    }

}

