using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    public GameObject[] tileToSpawn;
    public GameObject[] portalTiles;
    public GameObject referenceObject;
    public float timeOffset = 0.4f;
    public float distanceBetweenTile = 5.0f;
    public float randomValue = 0.8f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0,0,1), otherDirection = new Vector3(1,0,0);
    public GameObject coinPrefab;
    public GameObject portalPrefab;
    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue){
                direction = mainDirection;
            }
            else{
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTile * direction;
            startTime = Time.time;
            Instantiate(tileToSpawn[Random.Range(0,2)], spawnPos, Quaternion.Euler(0,0,0));
            int randval = Random.Range(0,100);
            if(randval > 98){
                SpawnCoins(spawnPos, portalPrefab);
            }else if(randval > 80){
                SpawnCoins(spawnPos, coinPrefab);
            }
            previousTilePosition = spawnPos;
        }
        
    }



    void SpawnCoins(Vector3 tileSpawnPos, GameObject prefab){
        GameObject temp = Instantiate(prefab);
        temp.transform.position = new Vector3(tileSpawnPos.x, tileSpawnPos.y + 1, tileSpawnPos.z);
    }


    // Vector3 GetRandomPointInCollider(Collider collider){
    //     Vector3 point = new Vector3(
    //         Random.Range(collider.bounds.min.x, collider.bounds.max.x),
    //         Random.Range(collider.bounds.min.y, collider.bounds.max.y),
    //         Random.Range(collider.bounds.min.z, collider.bounds.max.z)
    //     );

    //     if(point != collider.ClosestPoint(point)){
    //         point = GetRandomPointInCollider(collider);
    //     }

    //     point.y = 1;
    //     return point;
    // }

}
