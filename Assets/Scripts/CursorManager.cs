using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Transform cursor;

    private void Update()
    {
        cursor.position = Input.mousePosition;
        Cursor.visible = false;
    }
}
