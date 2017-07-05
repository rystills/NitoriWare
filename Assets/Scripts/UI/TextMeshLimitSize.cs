﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextMeshLimitSize : MonoBehaviour
{

#pragma warning disable 0649   //Serialized Fields
    [SerializeField]
    private Vector2 maxExtents;
    [SerializeField]
    private TextMesh textMesh;
    [SerializeField]
    private Renderer textRenderer;
    [SerializeField]
    private Vector3 defaultScale;
#pragma warning restore 0649

    void Awake()
	{
        if (textMesh == null)
            textMesh = GetComponent<TextMesh>();
        if (textRenderer == null)
            textRenderer = textMesh.GetComponent<Renderer>();
        if (maxExtents == Vector2.zero)
            maxExtents = textRenderer.bounds.extents;

        if (!Application.isPlaying)
        {
            defaultScale = transform.localScale;
            if (textMesh == null || textRenderer == null)
                enabled = false;
        }
	}

    void Start()
    {
        updateScale();
    }
    void LateUpdate()
    {
        updateScale();
    }

    public void updateScale()
    {
        transform.localScale = defaultScale;
        if (textRenderer.bounds.extents.x > maxExtents.x || textRenderer.bounds.extents.y > maxExtents.y)
            transform.localScale *= Mathf.Min(maxExtents.x / textRenderer.bounds.extents.x, maxExtents.y / textRenderer.bounds.extents.y);
    }
}
