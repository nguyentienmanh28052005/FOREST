using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Solid : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader myMaterial;
    public Color _color;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myMaterial = Shader.Find(("GUI/Text Shader"));
    }

    void ColorSprite()
    {
        myRenderer.material.shader = myMaterial;
        myRenderer.color = _color;
    }

    private void Update()
    {
        ColorSprite();
    }
}
