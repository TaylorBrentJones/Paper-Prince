using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemAttack;
	public int itemDefence;
	public ItemType itemType;

	public enum ItemType {
		Weapon,
		Consumable,
		Armor
	}

	public Item(string name, int id, string desc, int attack, int defence, ItemType type) 
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D> ("Item Icons/" + name);
		itemAttack = attack;
		itemDefence = defence;
		itemType = type;
	}

	public Item()
	{
		itemID = -1;
	}

}
