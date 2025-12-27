using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "New socasset", fileName = "socasset.asset")]
public class Soc_cpuMap : ScriptableObject, ISerializationCallbackReceiver
{
    public List<string> soc_list = new();
    private Dictionary<string, string> soc_code2cpu = new();
    private Dictionary<string, string> soc_name2cpu = new();
    public void OnBeforeSerialize() { }
    public void OnAfterDeserialize()
    {
        soc_code2cpu.Clear();
        soc_name2cpu.Clear();
        foreach (var soc in soc_list)
        {
            var parts = soc.Split(',');
            var cpu = parts[0];
            var soc_code = parts[1];
            var soc_name = parts[2];
            soc_code2cpu.TryAdd(soc_code, cpu);
            if (!string.IsNullOrEmpty(soc_name))
            {
                soc_name2cpu.TryAdd(soc_name, cpu);
            }
        }
    }
    /// <summary>
    /// Get the real cpu model from socinfo
    /// </summary>
    /// <param name="socinfo"></param>
    /// <returns></returns>
    public string GetRealCPUModel(string socinfo)
    {
        var infos = socinfo.Split('#');
        foreach (var info in infos)
        {
            if (soc_code2cpu.TryGetValue(info, out var actualCpu) || soc_name2cpu.TryGetValue(info, out actualCpu))
                return actualCpu;
        }
        return infos[2];//默认为hardware
    }
}