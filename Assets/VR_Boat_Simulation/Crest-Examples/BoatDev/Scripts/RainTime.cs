using UnityEngine;

public class AdjustParticleSystem : MonoBehaviour
{
    public int targetMaxParticles = 10000; // The target maximum particles
    public float duration = 240f; // Duration in seconds to reach the target (4 minutes)

    public ParticleSystem ps;
    private float startTime;
    private int initialMaxParticles;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Calculate the elapsed time
        float elapsedTime = Time.time - startTime;

        var main = ps.main;

        if (elapsedTime < duration)
        {
            // Interpolate the max particles value over the duration
            float t = elapsedTime / duration;
            int newMaxParticles = (int)Mathf.Lerp(initialMaxParticles, targetMaxParticles, t);
            main.maxParticles = newMaxParticles;
        }
        else
        {
            // Ensure maxParticles is set to the target value at the end
            main.maxParticles = targetMaxParticles;
        }
    }
}
