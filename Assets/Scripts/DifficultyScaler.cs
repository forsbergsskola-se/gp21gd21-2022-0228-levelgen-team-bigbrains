using System;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{
    /// <summary>
    /// this script goes on an empty DifficultyManager object and increments the hordes of enemies based on roomsCleared
    /// </summary>


    private int enemy1Count = 4;
    private int enemy2Count;
    private int enemy3Count;
    private int enemy4Count;

    public int roomsClearedTotal;

    private void Start()
    {
        roomsClearedTotal = 0;
    }

    private void ScaleDifficultyUp()
    {
        enemy1Count += roomsClearedTotal;
        enemy2Count += roomsClearedTotal;

        // do stuff like this to keep more difficult enemy amount down
        // e.g 4 roomsCleared = 2, 5 RoomsCleared = 2, 6 RoomsCleared = 3 (or 2 if floored from 2.5), 7 rooms = 3
        double half = roomsClearedTotal / 2;
        int half2 = Convert.ToInt32(Math.Floor(half));


        enemy3Count += half2;

        // even smaller amount
        enemy4Count += (int) Math.Floor(half / 2);


        Debug.Log($"{enemy1Count}");
        Debug.Log($"{enemy2Count}");
        Debug.Log($"{enemy3Count}");
        Debug.Log($"{enemy4Count}");
    }
}
