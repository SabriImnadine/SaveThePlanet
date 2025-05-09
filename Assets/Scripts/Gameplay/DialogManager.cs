using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;



public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI dialogText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }
    public bool IsReading => isReading;

    private void Awake ()
    {
        Instance = this;
    }

    bool isTyping;
    int currentLine = 0;
    Dialog currentDialog;
    bool isReading;

    public IEnumerator Showdialog(Dialog dialog )
    {
        yield return new WaitForEndOfFrame();  

        OnShowDialog?.Invoke();

        isReading = true;
        this.currentDialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            ++currentLine;
            
            if (currentLine < currentDialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(currentDialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                isReading = false;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);

        }
        isTyping = false;
    }
}
