using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    public void Awake() => Instance = this;
    [SerializeField]
    private GameObject instantiatorPrefab = null;
    [SerializeField]
    private GameObject platformPrefab = null;
    [SerializeField]
    private GameObject coinPrefab = null;
    [SerializeField]
    private float levelWidth = 3f;
    [SerializeField]
    private GameObject spikePrafab = null;
    [SerializeField]
    private GameObject heartPickupPrefab = null;
    private int tamMinY = 0;
    private int tamMaxY = 0;
    private int spawnAmount = 0;
    private int spawnCount = 0;
    private float lastSpawnY = 0;
    private int spawnChance = 0;
    private int maxDiffBetweenSpawns = 0;
    private int spawnCoinChance = 20;
    private int spawnSpikeChance = 40;
    private int heartPickupChance = 30;
    void Start()
    {
        spawnChunk();
    }

    public void spawnChunk()
    {
        #region Method 2.0
        getSpawnRates();
        bool firstLoopGone = false;
        spawnInstantiator();
        while (spawnCount < spawnAmount)
        {
            for (float i = tamMinY; i < tamMaxY; i++)
            {
                if (firstLoopGone && spawnCount >= spawnAmount)
                    break;
                if (Random.Range(0, spawnChance) == 0)
                {
                    spawnPrefab(i);
                }
                else if (lastSpawnY > maxDiffBetweenSpawns)
                {
                    spawnPrefab(i);
                }
            }
            firstLoopGone = true;
        }

        void spawnPrefab(float pos)
        {
            Vector3 spawnPos = new Vector3();
            spawnPos.y = pos;
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
            lastSpawnY = pos;
            spawnCount++;

            #region Spawn Coin
            if (Random.Range(0, spawnCoinChance) == 0)
            {
                Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            }
            else if (Random.Range(0, spawnSpikeChance) == 0)
            {
                Instantiate(spikePrafab, spawnPos, Quaternion.identity);
            }

            if (Random.Range(0, heartPickupChance) == 0)
            {
                Instantiate(heartPickupPrefab, spawnPos, Quaternion.identity);
            }
            #endregion
        }
        void spawnInstantiator()
        {
            Instantiate(instantiatorPrefab, new Vector3(0f, tamMaxY - 24f, 0f), Quaternion.identity);
        }
        #endregion
    }
    void getSpawnRates()
    {
        int score = GameMasterController.Instance.GetScore();
        #region Method 2.0
        if (score < 50)
        {
            tamMinY = 0;
            tamMaxY = 75;
            spawnAmount = 100;
            spawnChance = 1;
            maxDiffBetweenSpawns = 5;
            spawnCount = 0;
            spawnCoinChance = 15;
            spawnSpikeChance = 40;
            heartPickupChance = 30;
        }
        else if (score < 125)
        {
            tamMinY = 75;
            tamMaxY = 150;
            spawnAmount = 75;
            spawnChance = 2;
            maxDiffBetweenSpawns = 5;
            spawnCount = 0;
            spawnCoinChance = 12;
            spawnSpikeChance = 35;
            heartPickupChance = 30;
        }
        else if (score < 200)
        {
            tamMinY = 150;
            tamMaxY = 225;
            spawnAmount = 50;
            spawnChance = 4;
            maxDiffBetweenSpawns = 5;
            spawnCount = 0;
            spawnCoinChance = 10;
            spawnSpikeChance = 30;
            heartPickupChance = 30;
        }
        else if (score < 275)
        {
            tamMinY = 225;
            tamMaxY = 300;
            spawnAmount = 50;
            spawnChance = 5;
            maxDiffBetweenSpawns = 5;
            spawnCount = 0;
            spawnCoinChance = 8;
            spawnSpikeChance = 25;
            heartPickupChance = 30;
        }
        else if (score < 350)
        {
            tamMinY = 300;
            tamMaxY = 375;
            spawnAmount = 40;
            spawnChance = 5;
            maxDiffBetweenSpawns = 5;
            spawnCount = 0;
            spawnCoinChance = 6;
            spawnSpikeChance = 20;
            heartPickupChance = 30;
        }
        else
        {
            tamMinY = tamMaxY;
            tamMaxY = tamMaxY + 75;
            spawnAmount = 25;
            spawnChance = 5;
            maxDiffBetweenSpawns = 5;
            spawnCount = 0;
            spawnCoinChance = 5;
            spawnSpikeChance = 15;
            heartPickupChance = 30;
        }
        #endregion
    }
}
