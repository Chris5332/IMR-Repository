using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallThrowerDesktop : MonoBehaviour
{
    [Header("References")]
    public Transform handTransform;       
    public LineRenderer trajectoryLine;
    public float throwForce = 5f;
    public int trajectoryResolution = 30;
    public LayerMask groundMask;

    [Header("Score UI")]
    public TMP_Text scoreText;

    private Rigidbody heldBallRb;
    private bool isHolding = false;
    private int score = 0;
    private bool gameOver = false;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        if (gameOver) return;

        if (Input.GetKeyDown(KeyCode.G))
            PickUpClosestBall();

        if (!isHolding) return;

        heldBallRb.transform.position = handTransform.position;
        heldBallRb.transform.rotation = handTransform.rotation;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Throw button pressed");
            ThrowBall();
        }
    }

    void PickUpClosestBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length == 0) return;

        GameObject closest = null;
        float minDist = Mathf.Infinity;
        foreach (var ball in balls)
        {
            float dist = Vector3.Distance(handTransform.position, ball.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = ball;
            }
        }

        if (closest != null)
        {
            heldBallRb = closest.GetComponent<Rigidbody>();
            if (heldBallRb != null)
            {
                heldBallRb.isKinematic = true;
                isHolding = true;
                Debug.Log("Picked up " + closest.name);
            }
        }
    }

    void ThrowBall()
    {
        if (heldBallRb == null) return;

        heldBallRb.isKinematic = false;
        heldBallRb.AddForce(handTransform.forward * throwForce, ForceMode.VelocityChange);
        Debug.Log("Threw " + heldBallRb.name + " with force " + (handTransform.forward * throwForce));

        heldBallRb = null;
        isHolding = false;
    }

    public void AddScoreByDistance(float distance)
    {
        float multiplier = 10f; 
        int scoreToAdd = Mathf.Max(1, Mathf.RoundToInt(distance * multiplier));

        score += scoreToAdd;

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        Debug.Log("Added " + scoreToAdd + " points! Current score: " + score);
    }


    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
