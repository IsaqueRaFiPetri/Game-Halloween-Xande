using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        LockCursor();
    }

    private void Update()
    {
        if (Input.GetButtonDown("E"))
        {
            UnLockCursor();
            //objClosedHand.transform.parent = this.transform;
        }

        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
