using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionScript : MonoBehaviour
{

    [SerializeField] List<GameObject> allEnemies;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameManager;
    [SerializeField] Dictionary<string,int> scores;
    public  PositionScript instance;
    public int position;
    [SerializeField]List<string> players;
    private void Awake()
    {
        instance = this;
        scores = new Dictionary<string, int>();
    }
    private void Update()
    {
        if(gameManager.GetComponent<GameManager>().instance.isGameOver == false )
        {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
            if(player != null)
            {
                allEnemies.Add(player);
                
            }
            
            players = new List<string>();
            scores = GetScores(allEnemies);
            List<KeyValuePair<string, int>> list = scores.ToList();
            if(player != null)
            {
                position = list.FindIndex(key => key.Key == player.gameObject.name);//Getting player's rank
            }
            foreach (var item in list.OrderByDescending(key => key.Value))
            {
                if (item.Key != null)
                {
                    players.Add(item.Key);
                }


            }
        }
    }
    Dictionary<string,int> GetScores(List<GameObject> allEnemies)
    {
        Dictionary<string,int> scoresDict = new Dictionary<string,int>();
        
        for (int i = 0; i < allEnemies.Count; i++)
        {
            if (allEnemies[i] != null && allEnemies[i].gameObject.tag == "Player")
            {
                int score = gameManager.GetComponent<GameManager>().instance.score;
                string name = allEnemies[i].gameObject.name;
                scoresDict.Add(name, score);
            }
            else if(allEnemies[i] != null && allEnemies[i].gameObject.tag == "Enemy")
            {
                int score = allEnemies[i].GetComponent<GetEnemyScore>().instance.score;
                string name = allEnemies[i].gameObject.name;
                scoresDict.Add(name, score);
            }
            else if (allEnemies[i] == null)
            {
                scoresDict.Remove(allEnemies[i].gameObject.name);
            }
            
        }
        return scoresDict;
    }

}
