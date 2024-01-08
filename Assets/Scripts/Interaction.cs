using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public Actions action;

    [TextArea]
    public string responsee;

    public List<Item> itemToDisable = new List<Item>();
    public List<Item> itemToEnable = new List<Item>();

    public string textToMatch;

    public List<Connection> connectionToDisable = new List<Connection>();
    public List<Connection> connectionToEnable = new List<Connection>();

    public Location teleportLocation = null;
}
