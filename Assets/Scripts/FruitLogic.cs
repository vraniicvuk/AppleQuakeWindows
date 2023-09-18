using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitLogic : MonoBehaviour
{
    public float minDelayBetweenShots = 10f;
    private byte[] level;
    public LevelLoader loader;
    public string levelName = "Level1"; //Default level
    private int currentTurn = 0; //"Beat" of the level

    public LaunchFruit[] launchers = new LaunchFruit[4];

    public AudioSource source;
    public AudioClip clip;


    void Start()
    {
        //Load level from file - Levels are stored as arrays of 4-bit ints, each bit representing one fruit canon to fire
        level = loader.GetLevel(levelName);

        //Load launchers

        source.PlayOneShot(clip);

        launchers[0] = GameObject.FindGameObjectWithTag("NORTH_LAUNCHER").GetComponent<LaunchFruit>();
        launchers[1] = GameObject.FindGameObjectWithTag("EAST_LAUNCHER").GetComponent<LaunchFruit>();
        launchers[2] = GameObject.FindGameObjectWithTag("SOUTH_LAUNCHER").GetComponent<LaunchFruit>();
        launchers[3] = GameObject.FindGameObjectWithTag("WEST_LAUNCHER").GetComponent<LaunchFruit>();
        

        //Start
        InvokeRepeating("LaunchProjectile", 10.0f, minDelayBetweenShots);
        
    }

    
    void LaunchProjectile()
    {
        if (currentTurn >= level.Length + 5)
        {
            Application.Quit();
        }

        if (currentTurn >= level.Length)
        {
            currentTurn++;
            return;
        }

        //Using bitwise and we check if each binary int contains each of the components
        if ((level[currentTurn] & 8 )== 8) launchers[0].Launch();
        if ((level[currentTurn] & 4 )== 4) launchers[1].Launch();
        if ((level[currentTurn] & 2 )== 2) launchers[2].Launch();
        if ((level[currentTurn] & 1 )== 1) launchers[3].Launch();

        currentTurn++;
    }

}
