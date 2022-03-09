using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour
{
    private RoomTemplates rooms;
    private int rand;

    // this is a simple script to spawn a room
    // might need to add some rotation logic if the rooms are overlapping to make sure the openings are aligning properly?

    public void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    public void GenerateNewRoom()
    {
        rand = Random.Range(0, rooms.roomPrefabs.Length);
        Instantiate(rooms.roomPrefabs[rand], transform.position, Quaternion.identity);
    }

}
