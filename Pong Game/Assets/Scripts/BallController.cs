using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        LaunchBall();
    }

    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void LaunchBall()
    {
        float angle = Random.Range(10f, 30f);
        float rad = angle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        direction.y *= Random.value < 0.5f ? -1 : 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            speed = 8f;
            direction.x *= -1;
        }
        else if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            speed = 8f;
            float dis = transform.position.x - collision.transform.position.x;
            direction.x = dis;
            direction.y *= -1;
            direction = direction.normalized;
        }
        else if (collision.CompareTag("PointLimitPlayer1"))
        {
            ScoreController._instance.ChangeScore(ScoreController._instance._enemy);
            ResetBall();
        }
        else if (collision.CompareTag("PointLimitPlayer2"))
        {
            ScoreController._instance.ChangeScore(ScoreController._instance._player);
            ResetBall();
        }
    }

    private void ResetBall()
    {
        speed = 5f;
        transform.position = Vector3.zero;
        LaunchBall();
    }
}
