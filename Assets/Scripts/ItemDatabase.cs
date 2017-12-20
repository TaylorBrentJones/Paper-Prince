using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start()
	{
		items.Add (new Item ("Sword", 0, "Sword used to fight", 2, 0, Item.ItemType.Weapon));
		items.Add (new Item ("Chest Piece", 1, "Piece of armor used to defend yourself", 0, 4, Item.ItemType.Armor));
		items.Add (new Item ("Potion of Power", 2, "A potion that is used to make you more powerful", 1, 0, Item.ItemType.Consumable));

	}


}
