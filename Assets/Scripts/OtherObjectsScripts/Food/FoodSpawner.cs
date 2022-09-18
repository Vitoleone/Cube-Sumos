using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject Food;
    [SerializeField] float spawnRate;
    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        AddFoodToObjectList(enemies, newFood);
    }
    void AddFoodToObjectList(GameObject[] enemies, GameObject newFood)
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<EnemyMovement>().instance.allObjects.Add(newFood);
            }
            
        }
    }
}
