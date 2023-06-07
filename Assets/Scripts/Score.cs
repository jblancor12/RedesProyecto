using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror.Examples.Pong
{
    public class Score : NetworkBehaviour
    {
        private int ScorePlayer1 = 0;
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

        public void AddScore1()
        {
            ScorePlayer1 += 1;
            print(ScorePlayer1);
            
        }

        public void AddScore2()
        {

            
            ScorePlayer2 += 1;
            print(ScorePlayer2);
            
        }

    }
}

