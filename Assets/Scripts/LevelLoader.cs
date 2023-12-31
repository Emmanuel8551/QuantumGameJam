using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }
    [SerializeField] private Room roomFuture;
    [SerializeField] private Room roomPast;
    public Level level;
    public static int Nivel=1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeRoomPair(0);
    }

    public void LoadLevel (int level)
    {
        //Nivel = level;
        //ChangeRoomPair(0);
        Fader.Instance.FadeIn();
    }

    public void ChangeRoomPair (int roomIndex)
    {
        List<RoomEntry> entries = level.rooms;
        RoomEntry entry = entries[roomIndex];
        GameObject prefabPast = entry.roomPast;
        GameObject prefabFuture = entry.roomFuture;
        roomFuture.LoadRoomPrefab(prefabFuture);
        roomPast.LoadRoomPrefab(prefabPast);
    }
}

[System.Serializable]
public class Level
{
    public List<RoomEntry> rooms;
}

[System.Serializable]
public class RoomEntry
{
    public GameObject roomPast;
    public GameObject roomFuture;
}
