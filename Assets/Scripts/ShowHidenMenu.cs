using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowHidenMenu : MonoBehaviour
{
    public GameObject GO_menuGame;
    public GameObject GO_Button_ShowMenuGame;

  public void HidenMenu()
    {
        GO_menuGame.transform.DOScale(0, 1.5f);
        GO_Button_ShowMenuGame.SetActive(true);
    }

    public void ShowMenu()
    {
        GO_menuGame.transform.DOScale(1, 1f);
        GO_Button_ShowMenuGame.SetActive(false);
    }
}
