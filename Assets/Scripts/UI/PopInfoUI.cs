using UnityEngine.UI;

public class PopInfoUI : BaseUI
{
    public Button m_btnOk;
    public Text m_content;

    protected override void Awake()
    {
        base.Awake();
        InitBtns();
    }

    private void InitBtns()
    {
        m_btnOk.onClick.AddListener(Hide);
    }

    protected override void OnShow(object showItem)
    {
        var show = showItem as ShowItem;
        m_content.text = show.Desc;
    }

    public class ShowItem
    {
        public string Desc;
    }
}
