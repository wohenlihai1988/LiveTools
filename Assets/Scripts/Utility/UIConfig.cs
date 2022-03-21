using System.Collections.Generic;

public class ButtonItem
{
    public string ButtonName;
    public string FuncName;
}

public class UIConfig
{
    public string UIName;
    public string Title;
    public List<ButtonItem> Buttons = new List<ButtonItem>();
}
