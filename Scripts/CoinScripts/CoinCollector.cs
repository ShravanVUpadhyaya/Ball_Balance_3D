using UnityEngine;
using TMPro;


namespace ZombieLabyrinth.CoinSystem
{
    public class CoinCollector : MonoBehaviour
    {
        public int coinsCollected = 0;
        public TextMeshProUGUI coinText;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CoinTag")) 
            {
                CollectCoin(other.gameObject); 
                if (coinsCollected < 10)
                {
                    RespawnCoin(other.gameObject);
                }
            }
        }

        void CollectCoin(GameObject coin)
        {
            coin.SetActive(false);
            coinsCollected++;
            UpdateCoinsCollectedUI();
        }

        void RespawnCoin(GameObject coin)
        {
            coin.transform.position = GetRandomRespawnPosition(); 
            coin.SetActive(true); 
        }

        Vector3 GetRandomRespawnPosition()
        {
            return new Vector3(Random.Range(-44.8f, 45.2f), 1.5f, Random.Range(-43.1f, 44.5f));
        }
        void UpdateCoinsCollectedUI()
        {
            coinText.text = "Coins Collected: " + coinsCollected.ToString();
        }
    }
}
