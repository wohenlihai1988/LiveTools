using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button m_dateBtn;
    public Button m_orderBtn;
    public Text m_output;
    public GameObject m_popRoot;
    public Button m_btnPopOk;
    public Button m_btnPopCancel;
    public Text m_popDesc;
    private Func<bool> m_onPopOk;
    private Func<bool> m_onPopCancel;

    public void Start()
    {
        m_dateBtn.onClick.AddListener(ShowDate);
        m_orderBtn.onClick.AddListener(ShowOrder);
        InitPop();
    }

    private void InitPop()
    {
        m_popRoot.SetActive(false);
        m_btnPopOk.onClick.RemoveAllListeners();
        m_btnPopCancel.onClick.RemoveAllListeners();
        m_btnPopOk.onClick.AddListener(OnPopOk);
        m_btnPopCancel.onClick.AddListener(OnPopCancel);
    }

    private void ShowDate()
    {
        m_output.text = "";
        var stringBuilder = new StringBuilder();
        var days = DateUtility.GetNextGirlDay(new DateTime(2022, 1, 24), 28);
        var last = days[days.Count - 2];
        stringBuilder.AppendLine($"上一次是{last.ToShortDateString()}, {last.DayOfWeek}, 已经过了{(DateTime.Now - last).Days}天");
        var next = days[days.Count - 1];
        stringBuilder.AppendLine($"下一次是{last.ToShortDateString()}, {last.DayOfWeek}, 还有{(next - DateTime.Now).Days}天");
        stringBuilder.AppendLine($"宝宝我爱你，要注意身体啊，mua~");
        m_output.text = stringBuilder.ToString();
    }

    private void ShowOrder()
    {
        var rand = OrderUtility.GetEatingType();
        ShowPop($"我{RainbowUtility.GetGrilPrefix()}的宝宝， {rand} 好不好？", 
        ()=>
        {
            OrderUtility.AddEaten(rand);
            m_output.text = OrderUtility.GetHistoryDesc();
            return false;
        },
        ()=> {
            ShowOrder();
            return true;
        });
    }

    void DoInNextFrame(Action action)
    {
        StartCoroutine(CoroutineDoInNextFrame(action));
    }

    IEnumerator CoroutineDoInNextFrame(Action action)
    {
        yield return null;
        action?.Invoke();
    }

    private void ShowPop(string desc, Func<bool> onok, Func<bool> oncancel)
    {
        m_popRoot.SetActive(true);
        m_popDesc.text = desc;
        m_onPopOk = onok;
        m_onPopCancel = oncancel;
    }

    private void OnPopOk()
    {
        if(null != m_onPopOk)
        {
            m_popRoot.SetActive(m_onPopOk());
        }
        else
        {
            m_popRoot.SetActive(false);
        }
    }

    private void OnPopCancel()
    {
        if(null != m_onPopCancel)
        {
            m_popRoot.SetActive(m_onPopCancel());
        }
        else
        {
            m_popRoot.SetActive(false);
        }
    }
}
