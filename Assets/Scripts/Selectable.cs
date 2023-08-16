using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private Color origColor;
    [SerializeField] private Renderer targerRenderer;

    private void Start()
    {
        origColor = targerRenderer.material.color;
    }

    public void Select()
    {
        targerRenderer.material.color = Color.yellow;
    }

    public void Deselect()
    {
        targerRenderer.material.color = origColor;
    }
}
