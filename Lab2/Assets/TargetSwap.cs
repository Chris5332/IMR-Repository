using UnityEngine;
using System.Collections;

public class TargetSwap : MonoBehaviour
{
    public GameObject targetNormal;
    public GameObject targetGreen;

    public float glowDuration = 1f;

    public void ShowGreen()
    {
        if (targetNormal == null || targetGreen == null) return;
        StartCoroutine(SwapRoutine());
    }

    private IEnumerator SwapRoutine()
    {
        Debug.Log("Changing target color to green.");
        targetNormal.SetActive(false);
        targetGreen.SetActive(true);

        yield return new WaitForSeconds(glowDuration);

        Debug.Log("Reverting target color to normal.");
        targetNormal.SetActive(true);
        targetGreen.SetActive(false);
    }
}
