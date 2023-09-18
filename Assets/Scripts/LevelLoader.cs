using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    public string filepath;
    

    public byte[] GetLevel(string levelName)
    {
        filepath += Application.dataPath + "/Levels/" + levelName + ".txt";

        // Array of strings to ints
        string[] lines = File.ReadAllLines(filepath);
        byte[] linesI = new byte[lines.Length];
        
        //Turn strings into coded bytes and store them in linesI
        //Coded ints in 4-bit binary, where each bit refers to the side the shot is coming from
        //North = 8  E=4  S=2  W=1
        for (int x = 0; x < lines.Length; x++)
        {
            linesI[x] = Convert.ToByte ((lines[x].Contains('N')?1:0) * 8 + (lines[x].Contains('E')?1:0) * 4 + (lines[x].Contains('S')?1:0) * 2 + (lines[x].Contains('W')?1:0) * 1);
        }
        return linesI;
    }
}
