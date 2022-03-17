using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem
{
    public string Name;
    public string Icon;
    public int Cost;
}

public class ScoreRecordConfig
{
    public int Score;
    public string History;
}

public class ShopUI : BaseUI
{
    public Text m_title;
    public Transform m_itemRoot;
    private List<ShopItem> m_shopItems = new List<ShopItem>();

    protected override void OnShow(object showItem)
    {
        InitItems();
        ShowItems();
    }

    public void ShowItems()
    {
        var src = m_itemRoot.GetChild(0).gameObject;
        for(var i = 0; i < m_shopItems.Count; i++)
        {
            ShopItemUI item = null;
            GameObject child = null;
            if (i >= m_itemRoot.childCount)
            {
                child = Instantiate(src, m_itemRoot);
            }
            else
            {
                child = m_itemRoot.GetChild(i).gameObject;
            }
            item = child.GetComponent<ShopItemUI>();
            item.Show(m_shopItems[i]);
        }
        m_itemRoot.GetComponent<Layout>().Execute();
    }

    private void InitItems()
    {
        if(m_shopItems.Count < 1)
        {
            m_shopItems.Add(new ShopItem { Name = "亲亲", Cost = 0 });
            m_shopItems.Add(new ShopItem { Name = "抱抱", Cost = 0 });
            m_shopItems.Add(new ShopItem { Name = "举高高", Cost = 0 });
        }
    }
}
