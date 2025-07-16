using UnityEngine;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [System.Serializable] public class enemiseinawave{
        public GameObject mobPrefab; 
        public float spawnTime; 
        public float spawnInterval;
        public int enemiesperawave;
        public int enemiespawnedcount;
        }

    public List<enemiseinawave> enemiseinawaves; 
    public float spawnIntervalIncrementer = .91f;
    public int waveNo ;
    public Transform InsideBounds;
    public Transform OutsideBounds;
      
       
    private void SpawnMob()
    {
        Instantiate(enemiseinawaves[(int)waveNo].mobPrefab, RandomSpawnPoint(), Quaternion.identity);
        enemiseinawaves[(int)waveNo].enemiespawnedcount++;
    }

    public void AdjustSpawnIntervalIncrementer(string playstyle){
        if (playstyle == "Offensive")
        {
            spawnIntervalIncrementer = 0.9f;
        }
        else if (playstyle == "Defensive")
        {
            spawnIntervalIncrementer = 0.8f;
        }
        else
        {
            spawnIntervalIncrementer = 1.0f;
        }
    }

    private Vector2 RandomSpawnPoint()
    {
        
        
        Vector2 spawnpoint = Vector2.zero;
        if (UnityEngine.Random.Range(0, 3f) > 1)
        {
            spawnpoint.x = UnityEngine.Random.Range(InsideBounds.position.x, OutsideBounds.position.x);
            if (UnityEngine.Random.Range(0, 3f) > 1){
                spawnpoint.y = InsideBounds.position.y;
            }
            else{
                spawnpoint.y = OutsideBounds.position.y;
            }
        }
        else{
            spawnpoint.x = UnityEngine.Random.Range(InsideBounds.position.x, OutsideBounds.position.x);
            if (UnityEngine.Random.Range(0, 3f) > 1){
                spawnpoint.x = InsideBounds.position.x;
            }
            else{
                spawnpoint.x = OutsideBounds.position.x;
            }
        }
        return spawnpoint;
    }
    void Update()
    {
        if(MainPlayer_Anni.I.gameObject.activeSelf )
        {
            enemiseinawaves[(int)waveNo].spawnTime += Time.deltaTime;
            if(enemiseinawaves[(int)waveNo].spawnTime >= enemiseinawaves[(int)waveNo].spawnInterval)
            {
                enemiseinawaves[(int)waveNo].spawnTime = 0;
                SpawnMob(); 
            }
            if(enemiseinawaves[(int)waveNo].enemiespawnedcount >= enemiseinawaves[(int)waveNo].enemiesperawave)
            {
                enemiseinawaves[(int)waveNo].enemiespawnedcount = 0;
                if(enemiseinawaves[(int)waveNo].spawnInterval > .222567f)
                {
                    enemiseinawaves[(int)waveNo].spawnInterval *= spawnIntervalIncrementer;
                }
                waveNo++;
            }
            if(waveNo >= enemiseinawaves.Count)
            {
                waveNo = 0;
            }
        }
    }
}
    

    

    


