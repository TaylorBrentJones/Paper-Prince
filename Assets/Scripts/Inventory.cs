using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item> ();
	public List<Item> slots = new List<Item> ();
	private bool showInventory;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;
	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex; 

	// Use this for initialization
	void Start () {
		for (int i = 0; i < slotsX * slotsY; i++) {
			slots.Add (new Item ());
			inventory.Add (new Item ());
		}	
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase> ();
		AddItem (0);
		AddItem (1);
		AddItem (2);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown ("Inventory")) {
			showInventory = !showInventory;
		}
	}

	void OnGUI () {
		if (GUI.Button (new Rect (40, 400, 100, 40), "Save"))
		{
			SaveInventory ();
		}
		if(GUI.Button(new Rect(40,450,100,40), "Load"))
		{
			LoadInventory ();
		}
		tooltip = "";
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
			if(showTooltip)
			{
				GUI.Box (new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y,200,200), tooltip, skin.GetStyle("Tooltip"));
			}
		}
		if(draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y,50,50), draggedItem.itemIcon);
		}
	}

	void DrawInventory ()
	{
		Event e = Event.current;
		int i = 0;
		for(int y = 0; y < slotsY; y++)
		{
			for(int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect (x * 60, y * 60, 50, 50);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				slots [i] = inventory [i];
				Item item = slots [i];
				if (slots [i].itemName != null) {
					GUI.DrawTexture (slotRect, slots [i].itemIcon);
					if (slotRect.Contains (e.mousePosition)) {
						tooltip = CreateTooltip (slots [i]);
						showTooltip = true;
						if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem) {
							draggingItem = true;
							prevIndex = i;
							draggedItem = item;
							inventory [i] = new Item ();
						}
						if (e.type == EventType.mouseUp && draggingItem) {
							inventory [prevIndex] = inventory [i];
							inventory [i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if(e.isMouse && e.type == EventType.mouseDown && e.button == 1)
						{
							if(item.itemType == Item.ItemType.Consumable)
							{
								UseConsumable (slots [i], i, true);
							}
						}
					}
				} else {
					if(slotRect.Contains (e.mousePosition))
					{
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory [i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}	
					}
				}
				if(tooltip == "")
				{
					showTooltip = false;
				}
				i++;
			}
		}
	}

	string CreateTooltip(Item item)
	{
		tooltip = item.itemName + "\n" + item.itemDesc + "\n" + item.itemAttack + "\n" + item.itemDefence;
		return tooltip;
	}

	void RemoveItem(int id)
	{
		for(int i = 0; i < inventory.Count; i++)
		{
			if(inventory[i].itemID == id)
			{
				inventory [i] = new Item ();
				break;
			}	
		}	
	}

	void AddItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if (inventory [i].itemName == null) 
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory [i] = database.items [j];
					}
				}	
				break;
			}
		}
	}

	bool InventoryContains (int id)
	{
		bool result = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			result = inventory [i].itemID == id;
			if(result)
			{
				break;
			}	
		}	
		return result;
	}

	private void UseConsumable(Item item, int slot, bool deleteItem)
	{
		switch (item.itemID) 
		{
		case 2:
			{
				print ("used consumable");
				break;
			}
		}
		if(deleteItem)
		{
			inventory[slot] = new Item();
		}
	}

	void SaveInventory ()
	{
		for (int i = 0; i < inventory.Count; i++)
			PlayerPrefs.SetInt ("Inventory " + i, inventory [i].itemID);
	}

	void LoadInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
			inventory [i] = PlayerPrefs.GetInt ("Inventory " + i, -1) >= 0 ? database.items [PlayerPrefs.GetInt ("Inventory " + i)] : new Item ();
	}
}
