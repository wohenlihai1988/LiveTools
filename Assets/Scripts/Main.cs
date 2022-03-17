using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text m_infoContent;
    public GameObject m_infoRoot;
    public Button m_btnInfoOk;
    public ShopUI m_shopUI;
    public MainUI m_mainUI;
    public List<BaseUI> m_allUI;

    public void Awake()
    {
        for(var i = 0; i < m_allUI.Count; i++)
        {
            UIManager.Instance.Register(m_allUI[i]);
        }
    }

    public void Start()
    {
        UIManager.Instance.Init();
        UIManager.Instance.OpenUI<MainUI>(null);
    }
}