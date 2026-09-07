using Sandbox;
using System.Collections.Generic;

public sealed class Inventory : Component
{
    private Dictionary<string, int> Items = new();

    public void AddItem( string itemId, int amount = 1 )
    {
        if ( Items.ContainsKey( itemId ) )
        {
            Items[itemId] += amount;
        }
        else
        {
            Items[itemId] = amount;
        }

        Log.Info( $"{itemId}: {Items[itemId]}" );
    }
}