using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseSettingsPannel : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu = null;

    private bool isMenuOpen = false;

    private void OpenMenu()
    {
        settingsMenu.SetActive(true);
        isMenuOpen = true;
    }

    private void CloseMenu()
    {
        settingsMenu.SetActive(false);
        isMenuOpen = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }
}
