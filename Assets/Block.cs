using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int hitsRemaining = 5;
    private SpriteRenderer spriteRenderer;
    // [SerializeField]
    private TextMeshPro text;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red,  hitsRemaining / 10);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        hitsRemaining--;
        if (hitsRemaining > 0) UpdateVisualState();
        else {Destroy(gameObject);}
    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
}
