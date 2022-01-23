using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private static RoomController _roomController;
    private int currRoomIndex = 0;

    public List<GameObject> levelTiles;

    [SerializeField] private Transform InitialPoint;
    
    private void OnEnable()
    {
        if(_roomController)
            Destroy(_roomController);
        
        _roomController = this;
    }

    private void Awake()
    {
        if(InitialPoint)
            Instantiate(GetRoom(), InitialPoint.position, Quaternion.identity);
        else
        {
            Debug.Log("Cannot find the initial point");
        }
    }

    public static RoomController Get()
    {
        return _roomController;
    }

    public void SetNextRoom()
    {
        currRoomIndex++;
    }

    public GameObject GetRoom()
    {
        return levelTiles[currRoomIndex];
    }

    public bool IsGameOver()
    {
        return currRoomIndex == levelTiles.Count;
    }
}
