using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

these represent proxy positions according to the lego grid rather than actual transform values
as example, if we have a 2x2 brick besides a 4x2 brick, the 2x2 brick will be at position (0,0,0) and the 4x2 brick will be at position (2,0,0)

|* *||* * * *|
|* *||* * * *|

*/

public struct BrickVector
{
    public int GridX;
    public int GridY;
    public int GridZ;

    public BrickVector(int x, int y, int z)
    {
        GridX = x;
        GridY = y;
        GridZ = z;
    }

    public void Translate(BrickVector translation)
    {
        GridX += translation.GridX;
        GridY += translation.GridY;
        GridZ += translation.GridZ;
    }

    public void Translate(int x, int y, int z)
    {
        GridX += x;
        GridY += y;
        GridZ += z;
    }
}


public class LegoBrick
{
    [SerializeField]
    public BrickVector Position { get; set; }

    [SerializeField]
    public BrickVector Size { get; set; }

    // rather than silently forcing non-zero values or throwing exceptions in the setter, we can explicitly validate with Builder.ValidateSize()
    // and also account for max grid size
    // private BrickVector _size;
    // public BrickVector Size {
    // 	get => _size;
    //     set
    //     {
    //         _size.GridX = Math.Max(0, _size.GridX);
    // 		_size.GridY = Math.Max(0, _size.GridY);
    // 		_size.GridZ = Math.Max(0, _size.GridZ);
    //     }
    // 

    public GameObject gameObject;
}