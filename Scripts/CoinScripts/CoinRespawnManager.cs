using System.Collections.Generic;
using UnityEngine;

namespace ZombieLabyrinth.CoinSystem
{
    public class CoinRespawnManager : MonoBehaviour
    {
        public static CoinRespawnManager Instance;

        public GameObject coinPrefab;
        [SerializeField] private int poolSize = 10;

        private List<GameObject> pooledCoins;

        void Awake()
        {
            Instance = this;
            pooledCoins = new List<GameObject>();

            // Create the initial pool of coins
            for (int i = 0; i < poolSize; i++)
            {
                GameObject coin = Instantiate(coinPrefab);
                coin.SetActive(false);
                pooledCoins.Add(coin);
            }
        }

        public GameObject GetPooledCoin()
        {
            foreach (GameObject coin in pooledCoins)
            {
                if (!coin.activeInHierarchy)
                {
                    return coin;
                }
            }

            GameObject newCoin = Instantiate(coinPrefab);
            newCoin.SetActive(false);
            pooledCoins.Add(newCoin);
            return newCoin;
    }
}
}

