using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private float roomSize;
    public GameObject currentRoomGO;

    public void LoadRoomPrefab (GameObject roomPrefab)
    {
        if (currentRoomGO != null) Destroy(currentRoomGO);
        currentRoomGO = Instantiate(roomPrefab, transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one * roomSize);
    }
}
