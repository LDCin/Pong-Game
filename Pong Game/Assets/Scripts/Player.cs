using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _score = 0;
    private float screenMidY;
    [SerializeField] private bool isPlayer1 = true;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera mainCamera;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (mainCamera == null)
            mainCamera = Camera.main;
        screenMidY = Screen.height / 2f;
    }

    void Update()
    {
        rb.velocity = Vector2.zero;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (ControllPlayer(touch) && touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x;
                float worldDeltaX = deltaX / Screen.width * mainCamera.orthographicSize * 2f * mainCamera.aspect;
                Vector2 move = new Vector2(worldDeltaX * moveSpeed, 0f);
                rb.MovePosition(rb.position + move);
            }
        }
    }

    private bool ControllPlayer(Touch touch)
    {
        if (isPlayer1)
            return touch.position.y < screenMidY;
        else
            return touch.position.y >= screenMidY;
    }

    public void IncreaseScore()
    {
        _score++;
    }
    public int GetScore()
    {
        return _score;
    }
}
