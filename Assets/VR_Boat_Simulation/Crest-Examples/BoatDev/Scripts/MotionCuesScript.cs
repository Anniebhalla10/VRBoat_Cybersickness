using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCuesScript : MonoBehaviour
{
    public Transform MotionCue; 
    public Transform player; 
    public float radius = 2;
    public float cueLifetime = 2f; 
    public float spawnInterval = 0.5f; 
    public int numCues = 12; 
    public float verticalOffset = 1.0f; 

    private List<GameObject> cueList = new List<GameObject>();
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = player.position;
        StartCoroutine(SpawnCues());
    }

    IEnumerator SpawnCues()
    {
        while (true)
        {
            SpawnCuesOnCircle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCuesOnCircle()
    {
        Vector3 direction = player.position - previousPosition;
        if (direction != Vector3.zero)
        {
            direction.Normalize();
            Vector3 forwardDirection = player.forward;
            Vector3 upDirection = player.up;

            for (int i = 0; i < numCues; i++)
            {
                float angle = i * Mathf.PI * 2 / numCues;
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius + (float) 3.5;

                Vector3 spawnPosition = player.position + forwardDirection * verticalOffset + upDirection * y + player.right * x;
                GameObject tempObject = Instantiate(MotionCue, spawnPosition, Quaternion.identity).gameObject;
                tempObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); 
                tempObject.transform.parent = this.transform;
                cueList.Add(tempObject);
                StartCoroutine(MoveAndDespawnCue(tempObject, direction));
            }
        }
        previousPosition = player.position;
    }

    IEnumerator MoveAndDespawnCue(GameObject cue, Vector3 direction)
    {
        float elapsedTime = 0;
        while (elapsedTime < cueLifetime)
        {
            cue.transform.position += direction * -radius * Time.deltaTime / cueLifetime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cueList.Remove(cue);
        Destroy(cue);
    }
}






