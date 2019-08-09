using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home
{
    public int homeNumber;

    public bool isCleaned = false;

    public Room[] rooms;


    public RoomType[] roomTypes;

    readonly List<Roomdifficulty[]> first10HomeDiffs = new List<Roomdifficulty[]>
    {
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.easy, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.easy, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.Hard, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},

    };

    readonly List<Roomdifficulty[]> HomeDiffsLoop20 = new List<Roomdifficulty[]>
    {
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.Hard, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.medium, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.medium, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.Hard, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.medium, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.medium, Roomdifficulty.medium, Roomdifficulty.Hard},

    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.Hard, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.medium, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.medium, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.medium},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.medium, Roomdifficulty.Hard},
    new Roomdifficulty[] {Roomdifficulty.easy, Roomdifficulty.Hard, Roomdifficulty.Hard},

    };


    public Home(int number, int roomCount)
    {

        this.homeNumber = number;
        this.rooms = new Room[roomCount];
        this.roomTypes = new RoomType[roomCount];
    }
    public void SetupHome()
    {

        ShuffleRoomTypes();

        for (int i = 0; i < rooms.Length; i++)
        {
            var roomType = GetRoomType(i + 1);
            var prefabnumber = GetRoomTypePrefabNumber(roomType, i + 1);
            var roomDif = GetRoomDifficluty(i + 1);

            rooms[i] = new Room(roomType, roomDif, prefabnumber);
            rooms[i].SetUpRoom();
        }

    }



    private Roomdifficulty GetRoomDifficluty(int roomNumber)
    {
        Roomdifficulty diff;

        if (homeNumber <= 10)
        {
            diff = first10HomeDiffs[homeNumber - 1][roomNumber - 1];
        }
        else
        {
            var number20Loop = (homeNumber - 10) % 20;
            if (number20Loop == 0)
                number20Loop = 20;

            diff = HomeDiffsLoop20[number20Loop - 1][roomNumber - 1];

        }

        return diff;
    }

    private RoomType GetRoomType(int roomNumber)
    {
        return roomTypes[roomNumber - 1];
    }


    private int GetRoomTypePrefabNumber(RoomType roomType, int roomNumber)
    {
        int lastprefab = PlayerPrefs.GetInt(roomType.ToString(), -1);

        //TODO: fix if more than 5 prefab
        List<int> tempArray = new List<int> { 1, 2, 3, 4 };

        if (lastprefab > 0)
        {
            Debug.Log("Removed" + tempArray[lastprefab - 1]);
            tempArray.Remove(lastprefab - 1);

        }

        var shuffledTempArray = RandomNumberGenerator.ShuffleArray(tempArray.ToArray(), 999 - roomNumber);



        return shuffledTempArray[0];
    }

    private void ShuffleRoomTypes()
    {
        RoomType[] startArray = { RoomType.Kitchen, RoomType.Living, RoomType.Office };



        roomTypes = RandomNumberGenerator.ShuffleArray(startArray);
    }

}


