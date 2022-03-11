using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour {

    private RoomTemplates rooms;
    private int rand;

    // TODO: find each RoomConnectionPoint in the generated rooms prefab + connect to roomConnectionPoint1 etc...
    Vector3 roomConnectionPoint1, roomConnectionPoint2, roomConnectionPoint3, roomConnectionPoint4;

    // TODO: find intersection of current rooms "exit" roomConectionPoint and next room's "entry" connectionPoint
    Vector3 roomConnector;

    // this is a simple script to spawn a room
    // might need to add some rotation logic if the rooms are overlapping to make sure the openings are aligning properly?

    public void Start() {
        rooms = GameObject.FindGameObjectWithTag("RoomsTemplates").GetComponent<RoomTemplates>();
    }

    public void OnCollisionEnter(Collision collision) {
        // TODO: add logic for FogGate collision triggering GenerateNewRoom()
    }

    public void GenerateNewRoom() {
        rand = Random.Range(0, rooms.roomPrefabs.Length);
        //Instantiate(rooms.roomPrefabs[rand], transform.position, Quaternion.identity);
        Instantiate(rooms.roomPrefabs[rand], roomConnector, Quaternion.identity);
    }
}
