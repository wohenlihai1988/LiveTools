using UnityEngine.UI;

public partial class MainUI : BaseUI
{
    private Button m_dateBtn;
    private Button m_orderBtn;
    private Button m_ShopBtn;

    void InitBtns()
    {
        var buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            switch (button.name)
            {
                case "ButtonDate":
                    m_dateBtn.onClick.AddListener(ShowDate);
                    break;
                case "ButtonOrder":
                    m_orderBtn.onClick.AddListener(ShowOrder);
                    break;
                case "ButtonShop":
                    m_ShopBtn.onClick.AddListener(ShowShop);
                    break;
            }
        }
    }
}