using UnityEngine;

namespace Crest
{
    public class WindSpeedController : MonoBehaviour
    {
        public OceanRenderer oceanRenderer;
        public float maxWindSpeed = 150f; 
        public float increaseDuration = 300f; 

        private float initialWindSpeed = 0f; 
        private float currentWindSpeed;
        private float elapsedTime = 0f;

        void Start()
        {
            // Initialize the wind speed
            currentWindSpeed = initialWindSpeed;
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;
            currentWindSpeed = Mathf.Lerp(initialWindSpeed, maxWindSpeed, elapsedTime / increaseDuration);
            currentWindSpeed = Mathf.Clamp(currentWindSpeed, initialWindSpeed, maxWindSpeed);
            oceanRenderer._globalWindSpeed = currentWindSpeed;
            Debug.Log("Current Wind Speed: " + currentWindSpeed);
        }
    }
}
