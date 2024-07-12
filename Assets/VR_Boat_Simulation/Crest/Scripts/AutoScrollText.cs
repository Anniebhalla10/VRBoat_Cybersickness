using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;


public class AutoScrollText : MonoBehaviour
{

    private float scrollSpeed = 0.09f; // Speed of the scrolling text
    private RectTransform rectTransform;
    private float startPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition.y;
    }

    void Update()
    {
         // Calculate the new Y position based on the scroll speed and time
        float newYPosition = rectTransform.anchoredPosition.y + scrollSpeed * Time.deltaTime;

        // Check if the text has scrolled past its height
        // if (newYPosition >= rectTransform.rect.height)
        // {
        //     // Stop scrolling once the text has fully scrolled
        //     newYPosition = rectTransform.rect.height;
        // }

        // Update the Y position of the RectTransform
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newYPosition);
    }
}
