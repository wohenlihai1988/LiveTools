using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    private object m_lastShowItem;
    protected virtual void Awake()
    {
    }

    public void Show(object showItem = null)
    {
        gameObject.SetActive(true);
        if(null == showItem)
        {
            showItem = m_lastShowItem;
        }
        OnShow(showItem);
        m_lastShowItem = showItem;
    }

    protected abstract void OnShow(object showItem);

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void OpenUI<T>(object showItem = null) where T : BaseUI
    {
        UIManager.Instance.OpenUI<T>(this, showItem);
    }

    public void Close()
    {
        UIManager.Instance.CloseUI(this);
    }


    [ContextMenu("Activate")]
    public void Activate()
    {
        UIManager.Instance.Init();
        Show();
    }
}
