using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    List<LegoBrick> bricks = new List<LegoBrick>();

    BrickVector GridSize = new BrickVector(1000, 1000, 100);

    LegoBrick selected = null;

    public float GridToWorldScale = 10f;

    [SerializeField]
    private GameObject _brickPrefab;

    void Update()
    {
        // convert from data proxies to actual game objects
        foreach (LegoBrick brick in bricks)
        {
            if (brick.gameObject == null)
            {
                brick.gameObject = Instantiate(_brickPrefab);
                brick.gameObject.transform.SetParent(this.transform);
            }
            brick.gameObject.transform.position = new Vector3(brick.Position.GridX * GridToWorldScale, brick.Position.GridY * GridToWorldScale, brick.Position.GridZ * GridToWorldScale);
            brick.gameObject.transform.localScale = new Vector3(brick.Size.GridX * GridToWorldScale, brick.Size.GridY * GridToWorldScale, brick.Size.GridZ * GridToWorldScale);
        }

        UiManager.Instance.Highlight(selected);

        // ...
    }

    public void AddBrick(LegoBrick brick, BrickVector origin)
    {
        brick.Position.Translate(origin);
        ValidateSize(brick.Size);
        bricks.Add(brick);
    }

    // todo add helper methods for placing brick flush on edges of existing brick

    public void ValidateSize(BrickVector size)
    {
        if (size.GridX <= 0 || size.GridY <= 0 || size.GridZ <= 0)
        {
            Debug.LogWarning("Brick size must be non-zero, fixed automatically.");
            size.GridX = Math.Max(0, size.GridX);
            size.GridY = Math.Max(0, size.GridY);
            size.GridZ = Math.Max(0, size.GridZ);
        }
        else if (size.GridX > GridSize.GridX || size.GridY > GridSize.GridY || size.GridZ > GridSize.GridZ)
        {
            Debug.LogWarning("Brick size must not exceed grid size, fixed automatically.");
            size.GridX = Math.Min(size.GridX, GridSize.GridX);
            size.GridY = Math.Min(size.GridY, GridSize.GridY);
            size.GridZ = Math.Min(size.GridZ, GridSize.GridZ);
        }
    }

    public void LoadFile(string path)
    {
        bricks = Loader.BricksFromFile(path);
        selected = bricks[0];
    }
}