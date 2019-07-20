using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomRoot;

    public float roomHeight;
    public GameObject floor;
    public GameObject wall;
    public GameObject wallUpDown;

    public Texture[] flootRextures;
    public WallTextures[] wallTextures;
    public GameObject dust = null;

    [HideInInspector] public Room myRoom;

    public void CreateRoom(Room room)
    {
        myRoom = room;
        int textureUpDownnumber = RandomNumberGenerator.NextRandomInt(0, wallTextures.Length);

        //locate up/down walls
        var wallUp = GameObject.Instantiate(wallUpDown, room.upWallPosition(), room.upWallRotation(), roomRoot.transform);
        var wallDown = GameObject.Instantiate(wallUpDown, room.downWallPosition(), room.downWallRotation(), roomRoot.transform);
        wallUp.transform.localScale = wallDown.transform.localScale = room.upDownWallScale();

        wallUp.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].rightLeft;
        wallDown.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].rightLeft;

        //locate roght/left walls
        var wallLeft = GameObject.Instantiate(wall, room.leftWallPosition(), room.leftWallRotation(), roomRoot.transform);
        var wallRight = GameObject.Instantiate(wall, room.rightWallPosition(), room.rightWallRotation(), roomRoot.transform);
        wallLeft.transform.localScale = wallRight.transform.localScale = room.righLeftWallScale();

        wallLeft.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].upDown;
        wallRight.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].upDown;

        var floorGO = GameObject.Instantiate(floor, Vector3.zero, Quaternion.identity, roomRoot.transform);
        floorGO.transform.localScale = new Vector3(room.width + 0.5f, 0, room.length + 0.5f);
        floorGO.GetComponent<Renderer>().material.mainTexture = flootRextures[RandomNumberGenerator.NextRandomInt(0, flootRextures.Length, true)];

    }

    public void CreateDust(Room room, int xDistance, int yDistance)
    {

        var roomWidth = Mathf.CeilToInt(myRoom.width * 5) - 1;
        var roomLength = Mathf.CeilToInt(myRoom.length * 5) - 1;
        for (int i = -roomWidth; i < roomWidth; i += xDistance)
        {
            for (int k = -roomLength; k < roomLength; k += yDistance)
            {
                Vector3 pos = new Vector3(i, 0, k);
                var newDust = GameObject.Instantiate(dust, pos, Quaternion.identity);
                newDust.transform.SetParent(this.gameObject.transform);

            }
        }
    }
    public void DestroyRoom()
    {
        Destroy(roomRoot);
    }

    private void LocateObstacles()
    {

    }

    private float GetRandomValue(float min, float max)
    {

        return UnityEngine.Random.Range(min, max);
    }
    private int GetRandomValue(int min, int max)
    {

        return UnityEngine.Random.Range(min, max);
    }

    [System.Serializable]
    public struct WallTextures
    {
        public Texture upDown;
        public Texture rightLeft;

    }

}