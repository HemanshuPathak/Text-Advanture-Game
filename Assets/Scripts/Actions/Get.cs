using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Actions
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach(Item item in controller.player.currentLocation.items)
        {
            if(item.itemEnabled && item.itemName==noun)
            {
                if(item.playerCanTake)
                {
                    controller.player.Inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = " you take the " + noun;
                    return;
                }
            }
        }
        controller.currentText.text = " you can't take that ";
    }
}
