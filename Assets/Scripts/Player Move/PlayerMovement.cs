using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10f;
    bool movePlayer;
    Vector3 playerPos;
    Vector3 worldPosition;

    // Use this for initialization
    void Start () {
        Vector3 playerPos = transform.position;
    }

    // Update is called once per frame
    void Update () {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("clicked");
            movePlayer = true;
        }

        if (movePlayer) {
            playerPos = Vector3.MoveTowards(playerPos, worldPosition, speed * Time.deltaTime);
        }

        // if(movePlayer) {
        //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     playerPos = Vector3.MoveTowards(transform.position,new Vector3(mousePos.x, playerPos.y, mousePos.z),speed * Time.deltaTime);
        //     if(transform.position == mousePos) {
        //         movePlayer = false;
        //     }
        // }
    }
}
