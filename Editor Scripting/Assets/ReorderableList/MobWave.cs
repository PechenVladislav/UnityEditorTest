using UnityEngine;

[System.Serializable]
public struct MobWave {

    public enum WaveType { Boss, Mobs}

    public WaveType m_Type;
    public GameObject m_Prefab;
    public int m_Count;

}
