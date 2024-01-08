using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // To check items in the Room
        if (CheckItems(controller, controller.player.currentLocation.items, noun))
            return;

        // To check items in the Inventory
        if (CheckItems(controller, controller.player.Inventory , noun))
            return;

        controller.currentText.text = " You can't see a" + noun;
    }

    private bool CheckItems(GameController controller , List<Item> items , string noun)
    {
        foreach( Item item in items)
        {
            if(item.itemName == noun)
            {
                if (item.InteractWith(controller, "examine"))
                    return true;
                controller.currentText.text = " You see " + item.description;


                return true;
            }
        }
        return false;
    }

}
