using UnityEngine;

public class SoCUtils
{
    private const string JavaClassName = "SocUtils";

    public static string GetSocFullInfo()
    {
#if UNITY_ANDROID&& !UNITY_EDITOR
        try
        {
            using (var socUtils = new AndroidJavaClass(JavaClassName))
            {
                //返回信息：socmodel#platform#hardware
                return socUtils.CallStatic<string>("getSocInfo");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            return GetDefault();
        }

#else
        return GetDefault();
#endif
    }

    private static string GetDefault()
    {
        var type = SystemInfo.processorType;
        return $"{type}#{type}#{type}";
    }
}