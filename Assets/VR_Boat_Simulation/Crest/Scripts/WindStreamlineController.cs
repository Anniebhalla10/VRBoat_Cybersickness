using UnityEngine;

public class WindStreamlinesController : MonoBehaviour
{
    public Transform boatTransform; 
    public ParticleSystem windStreamlines; 
    private Vector3 previousBoatPosition;

    void Start()
    {
        previousBoatPosition = boatTransform.position;
    }

    void Update()
    {
        Vector3 boatDeltaPosition = boatTransform.position - previousBoatPosition;
        previousBoatPosition = boatTransform.position;

        if (boatDeltaPosition != Vector3.zero)
        {
            var main = windStreamlines.main;
            main.startSpeed = boatDeltaPosition.magnitude * 10f; 

            var shape = windStreamlines.shape;
            shape.rotation = new Vector3(0, Mathf.Atan2(boatDeltaPosition.x, boatDeltaPosition.z) * Mathf.Rad2Deg, 0);
        }
    }
}
