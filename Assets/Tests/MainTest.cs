using NUnit.Framework;
using System;
using UnityEngine;

public class MainTest
{
    [Test]
    public void TestDateTimeStringSwitch()
    {
        var dateTime = DateTime.Now;
        var jsonStr = dateTime.ToJsonString();
        Debug.Log($"jsonStr: {jsonStr}");
        Assert.AreEqual(dateTime.ToShortDateString(), jsonStr);
        var jsonDt = jsonStr.ToDateTime();
        Debug.Log($"jsonDt: {jsonDt}");
        Assert.AreEqual(dateTime.Date, jsonDt.Date);
    }
}
