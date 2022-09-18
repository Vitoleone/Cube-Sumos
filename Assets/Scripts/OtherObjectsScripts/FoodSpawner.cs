using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject Food;
    [SerializeField] float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnFood()
    {
        
        Vector3 foodSpawnPos = new Vector3(Random.insideUnitCircle.x * 20, 1f, Random.insideUnitCircle.y * 20);
        GameObject newFood = Instantiate(Food, foodSpawnPos, Quaternion.identity);
    }
}
