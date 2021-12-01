using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class WaveSpawner : MonoBehaviour
    {
        [System.Serializable]
        public class Wave
        {
            public Enemy[] enemies;
            public int enemyNum;
            public float timeBetweenSpawns;
        }

        public Wave[] waves;
        public Transform[] spawnPoints;
        public int timeBetweenWaves;
        public GameObject nextPortal;
        public GameObject exitPortal;

        private Transform player;
        private Wave currentWave;
        private int currentWaveIndex = 0;
        private bool finishedSpawning;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(StartNextWave());
            nextPortal.SetActive(false);
            exitPortal.SetActive(false);

        }

        IEnumerator StartNextWave()
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            StartCoroutine(SpawnEnemy(currentWaveIndex));
        }

        IEnumerator SpawnEnemy(int index)
        {
            currentWave = waves[index];
            for (int i = 0; i < currentWave.enemyNum; i++)
            {
                if (player == null)
                    yield break;
                Enemies.Enemy enemy = Instantiate(currentWave.enemies[Random.Range(0, currentWave.enemies.Length)],
                    spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
                enemy.transform.SetParent(transform.GetChild(0));
                yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
                if (i >= currentWave.enemyNum - 1)
                {
                    finishedSpawning = true;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void CountEnemies()
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && finishedSpawning)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 5 && currentWaveIndex + 1 < waves.Length)
                {
                    finishedSpawning = false;
                    currentWaveIndex++;
                    StartCoroutine(StartNextWave());
                }
                else
                {
                    finishedSpawning = false;
                    player.transform.position = new Vector2(0, 0);
                    Debug.Log("Congrats!");
                    nextPortal.SetActive(true);
                    exitPortal.SetActive(true);
                }
            }
        }
    }
}