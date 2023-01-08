using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Texture to use for the cursor
    public Texture2D cursorTexture;

    // Hotspot of the cursor (the point that is used to determine the position of the cursor)
    public Vector2 hotspot = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        // Set the cursor to the specified texture with the hotspot at the specified position
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }
}