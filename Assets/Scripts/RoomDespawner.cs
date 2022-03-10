using UnityEngine;

public class RoomDespawner : MonoBehaviour
{
    private void Update()
    {
        // get every room via its Spawner component
        var rooms2 = gameObject.GetComponents(typeof(Spawner));
        // cycle through each individual room
        foreach (var component in rooms2)
        {
            // destroy rooms that are ready to be destroyed
            if (component.GetComponent<Spawner>().readyToBeDestroyed)
            {
                Destroy(gameObject);
                Debug.Log($"{this.name} was deleted");
            }
        }
    }


    // // get every room via its tag
    // var rooms = GameObject.FindGameObjectsWithTag("Room");
    // // cycle through each room
    // foreach (var room in rooms)
    // {
    //     // // destroy rooms that are ready to be destroyed
    //     if (GetComponent<Spawner>().readyToBeDestroyed)
    //         Destroy(gameObject);
    // }
}

