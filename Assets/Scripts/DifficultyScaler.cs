using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{
    /// <summary>
    /// this script goes on an empty DifficultyManager object and increments the hordes of enemies based on roomsCleared
    /// </summary>


    private int Enemy1Count;
    private int Enemy2Count;
    private int Enemy3Count;
    private int Enemy4Count;

    public int RoomsCleared;

    private void Start()
    {
        RoomsCleared = 0;
    }

    private void ScaleDifficultyUp()
    {
        Enemy1Count =+ RoomsCleared;
        Enemy2Count =+ RoomsCleared;

        // do stuff like this to keep more difficult enemy amount down
        // e.g 4 roomsCleared = 2, 5 RoomsCleared = 2, 6 RoomsCleared = 3 (or 2 if floored from 2.5), 7 rooms = 3
        int Half =+ (int) (RoomsCleared /2 - 0.5f);
        Enemy3Count =+ Half;

        // even smaller amount
        Enemy4Count =+ (int) (Half / 2 - 0.5f);

        
        Debug.Log($"{Enemy1Count}");
        Debug.Log($"{Enemy2Count}");
        Debug.Log($"{Enemy3Count}");
        Debug.Log($"{Enemy4Count}");
    }
}
