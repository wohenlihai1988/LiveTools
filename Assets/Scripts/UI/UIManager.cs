using System;
using System.Collections.Generic;

public class UIManager
{
    private static UIManager m_instance = new UIManager();
    private List<BaseUI> m_allLastUI = new List<BaseUI>();
    public static UIManager Instance
    {
        get
        {
            return m_instance;
        }
    }
    private Dictionary<Type, BaseUI> m_allUI = new Dictionary<Type, BaseUI>();


    public void Register(BaseUI ui)
    {
        m_allUI[ui.GetType()] = ui;
    }

    public void OpenUI<T>(BaseUI lastUI, object showItem = null) where T : BaseUI
    {
        if(null != lastUI)
        {
            m_allLastUI.Add(lastUI);
        }
        m_allUI[typeof(T)].Show(showItem);
    }

    public void CloseUI(BaseUI ui)
    {
        ui.Hide();
        m_allLastUI[m_allLastUI.Count - 1].Show();
    }

    public void Init()
    {
        foreach(var uiPair in m_allUI)
        {
            uiPair.Value.Hide();
        }
    }

    public void Return()
    {
        var last = m_allLastUI.Count - 1;
        m_allLastUI[last].Hide();
        m_allLastUI.RemoveAt(last);
        if(m_allLastUI.Count > 0)
        {
            last = m_allLastUI.Count - 1;
            m_allLastUI[last].Show();
        }
    }
}
