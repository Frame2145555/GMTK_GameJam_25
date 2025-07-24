using UnityEngine;

public class UnitGFXHandler : MonoBehaviour
{
    UnitGFX m_currentUnitGFX;

    public UnitGFX CurrentUnitGFX
    {
        set
        {
            //value can be null
            if (m_currentUnitGFX != null)
                m_currentUnitGFX.PlayEndAnim();
            
            m_currentUnitGFX = value;

            if (m_currentUnitGFX != null)
                m_currentUnitGFX.PlayStartAnim();
        }
    }
}
