using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichMenus : MonoBehaviour
{
    [Header("MenuSwitch")]
    public GameObject MenuToClose;
    public GameObject MenuToOpen;

    public void Swtich()
    {
        MenuToOpen.SetActive(true);
        MenuToClose.SetActive(false);
    }
}
