using System.IO;
using System.Text;

public class UIGenerator
{
    public static void Generate(UIConfig uiconfig)
    {
        var buttonDefineStringBuilder = new StringBuilder();
        var buttonCaseStringBuilder = new StringBuilder();
        foreach(var button in uiconfig.Buttons)
        {
            buttonDefineStringBuilder.AppendLine($"private Button m_{button.ButtonName}");
            buttonCaseStringBuilder.AppendLine($"case \"{button.ButtonName}\": m_{button.ButtonName}.onClick.AddListener({button.FuncName}); break;");
        }
        var result = Template.Replace("#buttonDefine", buttonDefineStringBuilder.ToString()).Replace("#buttonCase", buttonCaseStringBuilder.ToString());
        File.WriteAllText($"Assets/Scripts/Generated/{uiconfig.UIName}.cs", result);
    }

    private const string Template = @"
using UnityEngine.UI;

public partial class MainUI : BaseUI
{
#buttonDefine

    void InitBtns()
    {
        var buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            switch (button.name)
            {
                #buttonCase
                case ""ButtonDate"":
                    m_dateBtn.onClick.AddListener(ShowDate);
                    break;
            }
        }
    }
}
";
}
