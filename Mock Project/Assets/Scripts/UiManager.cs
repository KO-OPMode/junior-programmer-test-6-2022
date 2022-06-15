using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager
{
    static private UiManager instance;
    static public UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UiManager();
            }
            return instance;
        }
        private set { instance = value; }
    }

    public void Highlight(LegoBrick brick)
    {
        brick.gameObject?.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }
}