using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public RoomSize MaxRoomSize;
    public RoomSize MinRoomSize;

    public float roomHeight;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject wallUpDown;

    [SerializeField] private Texture[] flootRextures;
    [SerializeField] private WallTextures[] wallTextures;

    [HideInInspector] public Room room;

    void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        CreateRoom();

    }

    private void CreateRoom()
    {
        //get  random room size
        float width = GetRandomValue(MinRoomSize.width, MaxRoomSize.width);
        float length = GetRandomValue(MinRoomSize.length, MaxRoomSize.length);

        room = new Room(width, length, roomHeight);


        //locate up/down walls
        var wallUp = GameObject.Instantiate(wallUpDown, room.upWallPosition(), room.upWallRotation(), this.transform);
        var wallDown = GameObject.Instantiate(wallUpDown, room.downWallPosition(), room.downWallRotation(), this.transform);
        wallUp.transform.localScale = wallDown.transform.localScale = room.upDownWallScale();
        int textureUpDownnumber = GetRandomValue(0, wallTextures.Length);
        wallUp.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].rightLeft;
        wallDown.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].rightLeft;


        // locate roght/left walls
        var wallLeft = GameObject.Instantiate(wall, room.leftWallPosition(), room.leftWallRotation(), this.transform);
        var wallRight = GameObject.Instantiate(wall, room.rightWallPosition(), room.rightWallRotation(), this.transform);
        wallLeft.transform.localScale = wallRight.transform.localScale = room.righLeftWallScale();

        wallLeft.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].upDown;
        wallRight.GetComponent<Renderer>().material.mainTexture = wallTextures[textureUpDownnumber].upDown;

        var floorGO = GameObject.Instantiate(floor, Vector3.zero, Quaternion.identity, this.transform);
        floorGO.transform.localScale = new Vector3(room.width + 0.5f, 0, room.length + 0.5f);
        floorGO.GetComponent<Renderer>().material.mainTexture = flootRextures[GetRandomValue(0, flootRextures.Length)];

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
    public struct RoomSize
    {
        public int width;
        public int length;

    }

    [System.Serializable]
    public struct WallTextures
    {
        public Texture upDown;
        public Texture rightLeft;

    }

}


