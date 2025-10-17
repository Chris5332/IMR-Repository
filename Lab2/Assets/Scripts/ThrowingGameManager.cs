using UnityEngine;
using UnityEngine.UI;

public class ThrowingGameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Text scoreText;
    public Text distanceText;

    [Header("Game Settings")]
    public Transform throwOrigin; // XR Origin position
    public float maxDistance = 15f; // Distanta maxima pentru scoring

    private int totalScore = 0;

    void Start()
    {
        UpdateUI();
    }

    public void CalculateScore(Vector3 hitPoint, Vector3 throwStartPoint)
    {
        // Calculeaza distanta de aruncare
        float throwDistance = Vector3.Distance(throwStartPoint, hitPoint);

        // Calculeaza scorul bazat pe distanta
        int distanceScore = Mathf.RoundToInt((throwDistance / maxDistance) * 100);

        // Adauga bonus pentru distante mari
        if (throwDistance > 10f)
            distanceScore += 50;
        else if (throwDistance > 7f)
            distanceScore += 25;

        totalScore += distanceScore;

        // Afiseaza rezultatul
        Debug.Log($"Aruncare de la {throwDistance:F2}m - Scor: {distanceScore}");
        UpdateUI();

        // Efect vizual (optional)
        ShowScoreEffect(hitPoint, distanceScore);
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Scor Total: " + totalScore;
    }

    void ShowScoreEffect(Vector3 position, int score)
    {
        // Aici poti adauga efecte vizuale - particule, text pop-up, etc.
        Debug.Log($"Scor obtinut: {score} puncte!");
    }
}
