using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    bool setMenu;

    private void Start()
    {
        menu.SetActive(false);
        setMenu = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && setMenu == false)//���j���[��\��
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
            setMenu = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && setMenu == true)//���j���[���Ƃ���
        {
            Time.timeScale = 1f;
            menu.SetActive(false);
            setMenu = false;
        }
    }
}
