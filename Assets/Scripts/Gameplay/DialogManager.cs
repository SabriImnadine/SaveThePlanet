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

    [SerializeField] private AudioSource sfxPlayer;
    [SerializeField] private AudioClip dialogAdvanceSound;

 


    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }
    public bool IsReading => isReading;

    private void Awake ()
    {
        Instance = this;
    }

    Action onDialogDone;
    bool isTyping;
    int currentLine = 0;
    Dialog currentDialog;
    bool isReading;

    public IEnumerator Showdialog(Dialog dialog, Action onDone=null )
    {
        yield return new WaitForEndOfFrame();  

        OnShowDialog?.Invoke();

        isReading = true;
        this.currentDialog = dialog;
        onDialogDone = onDone;

        dialogBox.SetActive(true);

         if (dialogAdvanceSound != null && sfxPlayer != null)
        sfxPlayer.PlayOneShot(dialogAdvanceSound);
        
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {

             if (dialogAdvanceSound != null && sfxPlayer != null)
            sfxPlayer.PlayOneShot(dialogAdvanceSound);


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
                onDialogDone?.Invoke();
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
