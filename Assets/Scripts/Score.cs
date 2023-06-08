using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror
{
    public class Score : NetworkBehaviour
    {   
        [SyncVar]
        private int ScorePlayer1 = 0;
        [SyncVar]
        private int ScorePlayer2 = 0;
        public TextMeshProUGUI TextScorePlayer1;
        public TextMeshProUGUI TextScorePlayer2;
        void Start()
        {
            TextScorePlayer1.GetComponent<TextMeshProUGUI>().text = ScorePlayer1.ToString();
            TextScorePlayer2.GetComponent<TextMeshProUGUI>().text = ScorePlayer2.ToString();
        }

        void Update()
        {
           TextScorePlayer1.GetComponent<TextMeshProUGUI>().text = ScorePlayer1.ToString();
           TextScorePlayer2.GetComponent<TextMeshProUGUI>().text = ScorePlayer2.ToString();
        }

        [ClientRpc]
        public void AddScore1()
        {
            ScorePlayer1 += 1;
            
        }

        [ClientRpc]
        public void AddScore2()
        {

            
            ScorePlayer2 += 1;
            
        }

    }
}

