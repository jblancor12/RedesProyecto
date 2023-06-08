using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Mirror
{
    public class Ball : NetworkBehaviour
    {
        public float speed = 30;
        public Rigidbody2D rigidbody2d;
        public Score score;
        private string side = "Right";
        GameObject ball;

        public override void OnStartServer()
        {
            base.OnStartServer();

            rigidbody2d.simulated = true;
            rigidbody2d.velocity = Vector2.right * speed;
            score = GameObject.FindGameObjectWithTag("Hud").GetComponent<Score>();
        }

        float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
        {
            return (ballPos.y - racketPos.y) / racketHeight;
        }
        
        public void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.GetComponent<Player>())
            {
                float y = HitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.y);

                float x = col.relativeVelocity.x > 0 ? 1 : -1;

                Vector2 dir = new Vector2(x, y).normalized;

                rigidbody2d.velocity = dir * speed;
            }

            Vector2 memory = rigidbody2d.velocity;
            if (col.gameObject.tag == "WallRight") {
                
                rigidbody2d.velocity = new Vector2(0, 0).normalized;
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                side = "Right";
                score.AddScore1();
                

                Invoke("restart", 1);
            }
            if (col.gameObject.tag == "WallLeft")
            {
                rigidbody2d.velocity = new Vector2(0, 0).normalized;
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                side = "Left";
                score.AddScore2();
                

                Invoke("restart", 1);            
            }
        }

        void restart()
        {
            if (side == "Right")
            {
                rigidbody2d.velocity = Vector2.right * speed;
            }
            else {
                rigidbody2d.velocity = Vector2.left * speed;
            }
                
        }

        public void speedUp()
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
            ball.GetComponent<Ball>().speed += 10;
        }
    }
}
