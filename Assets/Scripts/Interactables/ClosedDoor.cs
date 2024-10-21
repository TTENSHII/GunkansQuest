using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour , IInteractable
{
    [SerializeField] private AnimationClip openDoorAnimation = null;

    private AudioSource audioSource = null;
    private Animator animator = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public bool CanInteract()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Inventory>().haveLevelKey)
        {
            return true;
        }
        return false;
    }

    public string GetInteractText()
    {
        return "Press E to exit ship";
    }

    private void LoadNextLevel()
    {
        GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().LoadLevel(3);
    }

    public void Interact()
    {
        audioSource.Play();
        animator.SetTrigger("OpenDoor");
        Invoke("LoadNextLevel", openDoorAnimation.length);
    }
}
