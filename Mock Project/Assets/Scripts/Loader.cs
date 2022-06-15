using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class Loader
{
    public static List<LegoBrick> BricksFromFile(string path)
    {
        List<LegoBrick> bricks = new List<LegoBrick>();

        StreamReader lines = new StreamReader(path);
        while (!lines.EndOfStream)
        {
            string line = lines.ReadLine();
            string[] parts = line.Split(',');
            LegoBrick brick = new LegoBrick();
            brick.Position = new BrickVector(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            bricks.Add(brick);
        }
        return bricks;
    }
}