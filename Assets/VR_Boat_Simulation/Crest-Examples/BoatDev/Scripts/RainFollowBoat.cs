using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Crest.Spline.Spline;
using static UnityEngine.GraphicsBuffer;

public class RainFollowBoat : MonoBehaviour
{
    // Das Zielobjekt, dem gefolgt werden soll
    public Transform target;

    // Offset zwischen dem Zielobjekt und dem folgenden Objekt
    public Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Kein Zielobjekt gesetzt. Bitte ein Zielobjekt im Inspektor zuweisen.");
            return;
        }

        // Initiales Offset berechnen, falls nicht manuell gesetzt
        offset = transform.position - target.position;
    }



    private void LateUpdate()
    {
        if (target == null) return;

        // Position des Objekts anpassen, basierend auf dem Ziel und Offset
        transform.position = target.position + offset;
    }
}
