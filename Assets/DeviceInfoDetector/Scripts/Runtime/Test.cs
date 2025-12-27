using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Soc_cpuMap _socAsset;
    public Text info;
    private string msg;

    void Start()
    {
        var socInfo = SoCUtils.GetSocFullInfo();
       var realcpu = _socAsset.GetRealCPUModel(socInfo);
       msg = $"SocInfo:<color=red>{socInfo}</color>\nCpu model:<color=red>{realcpu}</color>";
    }

    private void OnGUI()
    {
        info.text = msg;
    }
}