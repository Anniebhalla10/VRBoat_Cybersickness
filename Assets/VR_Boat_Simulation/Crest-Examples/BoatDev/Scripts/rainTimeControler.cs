using UnityEngine;
using System.Collections;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem; // Referenz zum Partikelsystem
    public int maxParticlesValue = 1000; // Zielwert für maxParticles
    public float increaseDuration = 60f; // Dauer des Anstiegs (1 Minute)
    public float waitTime = 180f; // Wartezeit vor Beginn des Regens (3 Minuten)

    void Start()
    {
        // Startet die Coroutine
        StartCoroutine(GraduallyIncreaseRain());
    }

    IEnumerator GraduallyIncreaseRain()
    {
        // Wartezeit vor Beginn des Regens
        yield return new WaitForSeconds(waitTime);

        // Holen Sie sich die aktuelle Einstellung des Partikelsystems
        var emission = rainParticleSystem.emission;
        var main = rainParticleSystem.main;

        // Setzen Sie die Partikelanzahl auf 0 (kein Regen zu Beginn)
        main.maxParticles = 0;

        float elapsedTime = 0f;

        while (elapsedTime < increaseDuration)
        {
            // Berechne den neuen maxParticles-Wert
            float t = elapsedTime / increaseDuration;
            int newMaxParticles = (int)Mathf.Lerp(0, maxParticlesValue, t);

            // Setze den neuen Wert
            main.maxParticles = newMaxParticles;

            // Warten Sie auf den nächsten Frame
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Sicherstellen, dass der Endwert gesetzt ist
        main.maxParticles = maxParticlesValue;
    }
}
