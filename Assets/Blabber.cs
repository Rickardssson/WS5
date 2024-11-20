using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Blabber : MonoBehaviour
{
    public TextMeshProUGUI lineUI;
    public UnityEvent onDialogueStarted, onDialogueEnded;
    
    private Canvas dialogueCanvas;
    private Queue<string> upcomingLines;
    
    void Start()
    {
        dialogueCanvas = lineUI.canvas;
        dialogueCanvas.enabled = false;
    }

    public void StartTalking(TextAsset manuscript)
    {
        var lines = manuscript.text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        
        if (lines.Length == 0)
        {
            Debug.LogWarning("No lines" + manuscript.name);
            return;
        }
        upcomingLines = new Queue<string>(lines);
        lineUI.text = upcomingLines.Dequeue();
        dialogueCanvas.enabled = true;
        onDialogueStarted.Invoke();
    }

    public void ProgressDialogue(InputAction.CallbackContext context)
    {
        if (context.started && dialogueCanvas.enabled)
        {
            if (upcomingLines.Count > 0)
            {
                lineUI.text = upcomingLines.Dequeue();
            }
            else
            {
                dialogueCanvas.enabled = false;
                onDialogueEnded.Invoke();
            }
        }
    }
}
