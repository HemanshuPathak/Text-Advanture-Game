using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // To use items in the Room
        if (ReadItem(controller, controller.player.currentLocation.items, noun))
            return;

        // To use items in the Inventory
        if (ReadItem(controller, controller.player.Inventory, noun))
            return;

        controller.currentText.text = " There is no " + noun;
    }

    private bool ReadItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanUseItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }

                controller.currentText.text = "There is nothing on the " + noun + " That you can Read!";
                return true;
            }
        }
        return false;
    }
}

