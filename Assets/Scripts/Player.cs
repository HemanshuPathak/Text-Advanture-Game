﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;

    public List<Item> Inventory = new List<Item>();

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeLocation(GameController Controller, string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);

        if(connection != null)
        {
            if(connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Location destination)
    {
        currentLocation = destination;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
        
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach(Item item in Inventory)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
    }


    public bool HasItemByName(string noun)
    {
        foreach(Item item in Inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                return true;
            }
        }
        return false;
    }


    public bool CanReadItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

}
