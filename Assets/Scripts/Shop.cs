using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shop;
    public static Shop instance;

    private void Awake()
    {
        instance = this;
    }


    public void OpenShop()
    {
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }
}
