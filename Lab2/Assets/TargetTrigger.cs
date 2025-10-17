using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public BallThrowerDesktop scoreManager;
    public TargetSwap targetSwap;

    public Transform throwOrigin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log(other.name + " hit the target!");

            float distance = Vector3.Distance(throwOrigin.position, transform.position);

            if (scoreManager != null)
                scoreManager.AddScoreByDistance(distance);

            if (targetSwap != null)
            {
                targetSwap.ShowGreen();
            }
        }
    }
}
