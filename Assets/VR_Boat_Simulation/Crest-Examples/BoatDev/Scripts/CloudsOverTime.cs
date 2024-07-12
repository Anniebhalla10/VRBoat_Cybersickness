using UnityEngine;

public class CloudsAlphaController : MonoBehaviour
{
    public Material cloudsMaterial;  // Das Material, dessen Eigenschaft geändert werden soll
    public float duration = 240.0f;  // Dauer, nach der der Wert 2 erreicht werden soll (in Sekunden)
    private float startTime;

    void Start()
    {
        // Starte die Zeitmessung, wenn das Spiel startet
        startTime = Time.time;
    }

    void Update()
    {
        // Berechne die verstrichene Zeit seit dem Start
        float elapsedTime = Time.time - startTime;

        // Berechne den neuen Alpha-Wert
        // Wert wird linear von 0 bis 2 erhöht über die Dauer der Zeit
        float newAlpha = Mathf.Lerp(0, 2, elapsedTime / duration);

        // Setze den neuen Alpha-Wert im Material, beschränke aber den Wert auf maximal 2
        cloudsMaterial.SetFloat("_CloudsAlpha", Mathf.Min(newAlpha, 2.0f));
    }
}
