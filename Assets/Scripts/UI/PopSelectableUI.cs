using System;
using UnityEngine.UI;

public class PopSelectableUI : BaseUI
{
    public Button m_btnPopOk;
    public Button m_btnPopCancel;
    public Text m_popDesc;
    private Func<bool> m_onPopOk;
    private Func<bool> m_onPopCancel;

    protected override void Awake()
    {
        base.Awake();
        InitBtns();
    }

    public class ShowItem
    {
        public string desc;
        public Func<bool> onok;
        public Func<bool> oncancel;
    }

    protected override void OnShow(object showItem)
    {
        var show = showItem as ShowItem;
        ShowPop(show.desc, show.onok, show.oncancel);
    }

    private void InitBtns()
    {
        m_btnPopOk.onClick.RemoveAllListeners();
        m_btnPopCancel.onClick.RemoveAllListeners();
        m_btnPopOk.onClick.AddListener(OnPopOk);
        m_btnPopCancel.onClick.AddListener(OnPopCancel);
    }
    private void ShowPop(string desc, Func<bool> onok, Func<bool> oncancel)
    {
        m_popDesc.text = desc;
        m_onPopOk = onok;
        m_onPopCancel = oncancel;
    }

    private void OnPopOk()
    {
        if(null != m_onPopOk)
        {
            if(!m_onPopOk())
            {
                Hide();
            }
        }
        else
        {
            Hide();
        }
    }

    private void OnPopCancel()
    {
        if(null != m_onPopCancel)
        {
            if(!m_onPopCancel())
            {
                Hide();
            }
        }
        else
        {
            Hide();
        }
    }
}
