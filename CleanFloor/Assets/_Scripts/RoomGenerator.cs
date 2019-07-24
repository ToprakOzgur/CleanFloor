using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    [HideInInspector] public RoomSize roomSize;
    public GameObject roomRoot;

    public float roomHeight;
    public GameObject floor;
    public Material wallLeftRightMaterial;
    public Material wallUpDownMaterial;

    public Texture[] flootRextures;
    public WallTextures[] wallTextures;
    public GameObject dust = null;

    public RoomType roomType;

    [HideInInspector] public int dustCount = 0;

    private void Awake()
    {

        GameObject.Instantiate(roomRoot, Vector3.zero, Quaternion.identity);
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
    }
    public void CreateRoomColor()
    {

        int textureUpDownnumber = RandomNumberGenerator.NextRandomInt(0, wallTextures.Length);


        wallUpDownMaterial.mainTexture = wallTextures[textureUpDownnumber].upDown;
        wallLeftRightMaterial.mainTexture = wallTextures[textureUpDownnumber].rightLeft;

        // var floorGO = GameObject.Instantiate(floor, Vector3.zero, Quaternion.identity, roomRoot.transform);
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
        dustCount = points.Count;

        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                Vector3 pos = new Vector3(point.x - roomSize.width * 5 + wallEdgesSpace / 2, 0, point.y - roomSize.length * 5 + wallEdgesSpace / 2);
                var newDust = GameObject.Instantiate(dust, pos, Quaternion.identity);
                newDust.transform.SetParent(this.gameObject.transform);
            }
        }
    }
    public void DestroyRoom()
    {
        Destroy(roomRoot);
    }

    [System.Serializable]
    public struct WallTextures
    {
        public Texture upDown;
        public Texture rightLeft;

    }


    [System.Serializable]
    public struct RoomSize
    {
        public int width;
        public int length;

    }

}