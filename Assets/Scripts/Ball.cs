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
        GameObject ball;

        public override void OnStartServer()
        {
            base.OnStartServer();

            // only simulate ball physics on server
            rigidbody2d.simulated = true;
            // Serve the ball from left player
            rigidbody2d.velocity = Vector2.right * speed;
            score = GameObject.FindGameObjectWithTag("Hud").GetComponent<Score>();
        }

        float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
        {
            // ascii art:
            // ||  1 <- at the top of the racket
            // ||
            // ||  0 <- at the middle of the racket
            // ||
            // || -1 <- at the bottom of the racket
            return (ballPos.y - racketPos.y) / racketHeight;
        }

        // only call this on server
        
        public void OnCollisionEnter2D(Collision2D col)
        {
            // Note: 'col' holds the collision information. If the
            // Ball collided with a racket, then:
            //   col.gameObject is the racket
            //   col.transform.position is the racket's position
            //   col.collider is the racket's collider

            // did we hit a racket? then we need to calculate the hit factor
            if (col.transform.GetComponent<Player>())
            {
                // Calculate y direction via hit Factor
                float y = HitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.y);

                // Calculate x direction via opposite collision
                float x = col.relativeVelocity.x > 0 ? 1 : -1;

                // Calculate direction, make length=1 via .normalized
                Vector2 dir = new Vector2(x, y).normalized;

                // Set Velocity with dir * speed
                rigidbody2d.velocity = dir * speed;
            }

            Vector2 memory = rigidbody2d.velocity;
            if (col.gameObject.tag == "WallRight") {
                
                rigidbody2d.velocity = new Vector2(0, 0).normalized;
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                score.AddScore1();
                
                //score2.GetComponent<TextMeshProUGUI>().text = scoreKeep2.ToString();

                Invoke("restart", 1);
            }
            if (col.gameObject.tag == "WallLeft")
            {
                rigidbody2d.velocity = new Vector2(0, 0).normalized;
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);

               score.AddScore2();
                
                //score1.GetComponent<TextMeshProUGUI>().text = scoreKeep1.ToString();

                Invoke("restart", 1);            
            }
        }

        void restart()
        {
            int num = Random.Range(1, 100);
            if (num>50)
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
