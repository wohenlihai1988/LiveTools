using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public Text m_content;
    public void Show(ShopItem item)
    {
        m_content.text = $"{item.Name}({item.Cost}积分)";
    }
}
