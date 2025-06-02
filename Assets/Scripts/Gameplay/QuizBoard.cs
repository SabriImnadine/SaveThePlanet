using UnityEngine;

public class QuizBoard : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject quizCanvas;

    public void Interact(Transform initiator)
    {
        if (quizCanvas != null)
        {
            quizCanvas.SetActive(true);
            PlayerController.i.enabled = false; 
        }
    }
}
