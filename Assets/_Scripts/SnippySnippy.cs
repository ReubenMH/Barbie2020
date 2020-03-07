using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class cutEvent: UnityEvent<float, float> {}

public class SnippySnippy : MonoBehaviour
{
    public bool cutStarted = false;
    private Vector2 cutStart;

    private Vector2 cutEnd;

    public cutEvent cutEvent = new cutEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!cutStarted) {
                cutStart = Input.mousePosition;
            } else {
                cutEnd = Input.mousePosition;
                float gradient = (cutStart.y - cutEnd.y)/(cutStart.x - cutEnd.x);
                float intercept = cutStart.y - gradient*cutStart.x;
                cutEvent.Invoke(gradient, intercept);
            }
        }
    }
}
