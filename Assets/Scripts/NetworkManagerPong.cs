using UnityEngine;
using UnityEngine.UI;

namespace Mirror
{
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager
    {
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;
        GameObject ball;
    
        public bool gameStart = false;

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);
            
            if (numPlayers == 2)
            {
                ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
                NetworkServer.Spawn(ball);
                ball.tag = "Ball";

                gameStart = true;
            }
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            if (ball != null)
                NetworkServer.Destroy(ball);

            base.OnServerDisconnect(conn);
            gameStart = false;
        }

        public bool getGameStart()
        {
            
            return gameStart;
        }


    }
}
