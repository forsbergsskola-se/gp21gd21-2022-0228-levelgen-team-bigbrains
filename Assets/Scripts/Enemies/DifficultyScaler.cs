using System;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour {
    /// <summary>
    /// this script goes on an empty DifficultyManager object and increments the hordes of enemies based on roomsCleared
    /// </summary>

    public int enemy1Count;
    public int enemy2Count;
    public int enemy3Count;
    public int enemy4Count;

    public int roomsClearedTotal;

    private void Start() {
        roomsClearedTotal = 0;
    }

    public void ScaleDifficultyUp() {
        roomsClearedTotal++;

        double half = roomsClearedTotal / 2;
        int halfFloored = Convert.ToInt32(Math.Floor(half));
        double sqrt = Math.Sqrt(roomsClearedTotal);
        int sqrtFloored = Convert.ToInt32(Math.Floor(sqrt));

        enemy1Count += roomsClearedTotal;
        enemy2Count += roomsClearedTotal;
        enemy3Count += halfFloored;
        enemy4Count += sqrtFloored;
    }
}
