using System;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour {
    /// <summary>
    /// this script goes on an empty DifficultyManager object and increments the hordes of enemies based on roomsCleared
    /// </summary>

    public int enemy1Count = 4;
    public int enemy2Count;
    public int enemy3Count;
    public int enemy4Count;

    public int roomsClearedTotal;

    private void Start() {
        roomsClearedTotal = 0;
    }

    private void ScaleDifficultyUp() {
        double half = roomsClearedTotal / 2;
        int halfFloored = Convert.ToInt32(Math.Floor(half));
        double sqrt = Math.Sqrt(roomsClearedTotal);
        int sqrtFloored = Convert.ToInt32(Math.Floor(sqrt));

        enemy1Count += roomsClearedTotal;
        enemy2Count += roomsClearedTotal;
        enemy3Count += halfFloored;
        enemy4Count += sqrtFloored;

        // Debug.Log($"{enemy1Count}");
        // Debug.Log($"{enemy2Count}");
        // Debug.Log($"{enemy3Count}");
        // Debug.Log($"{enemy4Count}");
    }
}
