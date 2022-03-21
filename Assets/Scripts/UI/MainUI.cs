using System;
using System.Text;
using UnityEngine.UI;

public partial class MainUI : BaseUI
{
    protected override void OnShow(object showItem)
    {
        InitBtns();
    }

    private void ShowDate()
    {
        var stringBuilder = new StringBuilder();
        var days = DateUtility.GetNextDays(new DateTime(2022, 1, 24), 28, DateUtility.AddDays);
        var last = days[days.Count - 2];
        stringBuilder.AppendLine($"上一次是{last.ToShortDateString()}, {last.DayOfWeek}, 已经过了{(DateTime.Now - last).Days}天");
        var next = days[days.Count - 1];
        stringBuilder.AppendLine($"下一次是{last.ToShortDateString()}, {last.DayOfWeek}, 还有{(next - DateTime.Now).Days}天");
        stringBuilder.AppendLine($"宝宝我爱你，要注意身体啊，mua~");
        OpenUI<PopInfoUI>(new PopInfoUI.ShowItem { Desc = stringBuilder.ToString() });
    }

    private void ShowShop()
    {
        Hide();
        OpenUI<ShopUI>();
    }

    private void ShowOrder()
    {
        var rand = OrderUtility.GetEatingType();
        OpenUI<PopSelectableUI>(new PopSelectableUI.ShowItem
        {
            desc = $"我{RainbowUtility.GetGrilPrefix()}的宝宝， {rand} 好不好？",
            onok = () =>
            {
                OrderUtility.AddEaten(rand);
                OpenUI<PopInfoUI>(new PopInfoUI.ShowItem
                {
                    Desc = OrderUtility.GetHistoryDesc()
                });
                return false;
            },
            oncancel = () =>
            {
                ShowOrder();
                return true;
            }
        });
    }
}
