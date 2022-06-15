using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegoShop : MonoBehaviour
{
    // track current and past browse history for this session as player navigates different bricks
    public History History = new History();

    public Text Title;
    public Text Description;


    void Start()
    {
        RefreshPreview();
    }

    void Update()
    {
        // ...
    }

    // player has selected a brick to preview for purchase

    void SelectItem(ShopItem item)
    {
        History.CurrentItem = item;
        RefreshPreview();
    }

    // can be mapped to a back button in the UI

    void SelectPrevious()
    {
        ShopItem item = History.PreviousItem;
        RefreshPreview();
    }

    void RefreshPreview()
    {
        // render current item - must have a key
        if (!String.IsNullOrEmpty(History.CurrentItem.Key))
        {
            Title.text = History.CurrentItem.FormattedText;
            // we only render based off the key, not the entire item
            RenderBrick(History.CurrentItem.Key);
        }
    }

    // render all history items in reverse order (most recent first)
    void ViewHistory()
    {
        for (int i = History.counter; i > 0; i--)
        {
            // todo render History.Items[i] in a grid?
        }
    }

    void RenderBrick(string key)
    {
        // ...
    }
}

public class ShopItem
{
    public String Key;
    public String Name = "Generic Brick";
    public float Price;

    public String FormattedText => $"${Price} {Name} [{Key}]";
}

public class History
{
    // keep a max size of 10 - keep it private so we can't accidentally change it
    public ShopItem[] items { get; private set; } = new ShopItem[10];
    public int counter { get; private set; } = 0;

    public ShopItem CurrentItem
    {
        get { return items[counter]; }
        set
        {
            // move all the existing entries down to accommodate the new one
            if (counter > items.Length - 1)
            {
                for (int index = 1; index <= items.Length; index++)
                    items[index - 1] = items[index];
            }
            items[counter] = value;
            if (counter < items.Length - 1)
                counter++;
        }
    }

    public ShopItem PreviousItem
    {
        get
        {
            if (counter == 0)
            {
                if (items[0] == null)
                    return null;
                else
                    return items[0];
            }
            else
            {
                counter--;
                return items[counter + 1];
            }
        }
    }
}

