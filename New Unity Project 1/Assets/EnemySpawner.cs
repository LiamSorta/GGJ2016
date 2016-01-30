using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    int maxEnemies;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Level1)
        {
            maxEnemies = 5;
        }
        if (Level2)
        {
            maxEnemies = 10;
        }

        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject instance = Instantiate(enemy, RandomPos, Quaternion.identity) as GameObject;
            AIScript stats = instance.GetComponent<AIScript>();
            switch (Element)
            {
                case "Water":
                    stats.SetStats(1.25f, 0.75f, 1f, 1f, Color.blue, false);
                    break;
                case "Fire":
                    stats.SetStats(0.75f, 1.25f, 1f, 1f, Color.red, false);
                    break;
                case "Earth":
                    stats.SetStats(1f, 1f, 0.75f, 0.75f, Color.gray, true);
                    break;
                case "Air":
                    stats.SetStats(1f, 1f, 1.25f, 1.25f, Color.white, true);
                    break;
                default:
                    stats.SetStats(1f, 1f, 1f, 1f, Color.white, false);
                    break;
            }
        }
	}
}
