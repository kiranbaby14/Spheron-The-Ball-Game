using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tilePrefabs;

    public Transform playerTransform;
    private float spawnZ = 1716f;//1664.8f;
    private float tileLength = 200f;//97.48247f;
    private int amnTilesOnScreen = 5;
    private float safeZone = 150f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;
    void Start()
    {
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i< amnTilesOnScreen; i++)
        {
           SpawnTile();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerTransform.position.z - safeZone  > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            //DeleteTile();
        }
    }


    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;  
        go = Instantiate(tilePrefabs[RandomPrefabIndex()], new Vector3(0.002f, -1f, spawnZ), Quaternion.Euler(0, 0, 0)) as GameObject;
        go.transform.SetParent(transform);

        spawnZ += tileLength;
        activeTiles.Add(go);

    }

   // private void DeleteTile()
   // {
      //  Destroy(activeTiles[0]);
      //  activeTiles.RemoveAt(0);
    //}

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
