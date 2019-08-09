using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomGenerator : MonoBehaviour
{


    [HideInInspector] public RoomSize roomSize;
    public GameObject[] roomRoot;

    public float roomHeight;
    public GameObject floor;
    public Material wallLeftRightMaterial;
    public Material wallUpDownMaterial;

    public Texture[] flootRextures;
    public WallTextures[] wallTextures;

    [SerializeField] private ObstacleManager obstacleManager;


    [HideInInspector] public GameObject roomName;


    private void Awake()
    {

        roomName = GameObject.Instantiate(roomRoot[RandomNumberGenerator.seed - 1], Vector3.zero, Quaternion.identity);

        GetRoomSizes();
    }
    private void GetRoomSizes()
    {
        roomSize.width = (int)GameObject.FindGameObjectWithTag("WallUp").transform.localScale.x;
        roomSize.length = (int)GameObject.FindGameObjectWithTag("WallLeft").transform.localScale.x;
    }
    private void Start()
    {

        CreateRoomColor();
        CreateDust();
        CreateObstacles();

    }
    public void CreateRoomColor()
    {
        int textureUpDownnumber = RandomNumberGenerator.NextRandomInt(0, wallTextures.Length);

        wallUpDownMaterial.mainTexture = wallTextures[textureUpDownnumber].upDown;
        wallLeftRightMaterial.mainTexture = wallTextures[textureUpDownnumber].rightLeft;

        var floorGO = GameObject.FindGameObjectWithTag("Floor");
        floorGO.GetComponent<Renderer>().sharedMaterial.mainTexture = flootRextures[RandomNumberGenerator.NextRandomInt(0, flootRextures.Length, 9999)];

    }

    public void CreateDust()
    {
        float radius = 1f;
        float wallEdgesSpace = 2;
        Vector2 regionSize = new Vector2(roomSize.width * 10 - wallEdgesSpace, roomSize.length * 10 - wallEdgesSpace);
        int rejectionSamples = 10;
        List<Vector2> points;

        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);

        Vacuum vacuum = GameObject.FindObjectOfType<Vacuum>();

        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                Vector3 pos = new Vector3(point.x - roomSize.width * 5 + wallEdgesSpace / 2, 0, point.y - roomSize.length * 5 + wallEdgesSpace / 2);
                var newDust = DustPool.Instance.Get();
                newDust.transform.position = pos;
                newDust.SetActive(true);
                newDust.transform.SetParent(this.gameObject.transform);
                vacuum.dustCount++;
            }

        }
    }

    public void CreateObstacles()
    {
        //TODO:fix this
        RoomType roomType = RoomType.Common;

        if (RandomNumberGenerator.seed <= 4)
        {
            roomType = RoomType.Kitchen;
        }
        else if (RandomNumberGenerator.seed <= 8)
        {
            roomType = RoomType.Living;
        }
        else if (RandomNumberGenerator.seed <= 12)
        {
            roomType = RoomType.Office;
        }




        obstacleManager.CreateObstacles(roomType);
    }
    public void DestroyRoom()
    {
        // Destroy(roomRoot);
    }

    [System.Serializable]
    public struct WallTextures
    {
        public Texture upDown;
        public Texture rightLeft;
    }

    public struct RoomSize
    {
        public int width;
        public int length;
    }


}