using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scrollSpeed = -1f;
    float spriteSize;
    Vector2 startPos;

    void Start() {
        startPos = new Vector2(0, -85f);
        spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update() {
        float newPos = Mathf.Repeat (Time.time * scrollSpeed, spriteSize);
        transform.position = startPos + Vector2.up * newPos;
    }
}
