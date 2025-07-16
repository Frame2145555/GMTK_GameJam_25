using UnityEngine;
using System.Collections.Generic;

public class UnitGFXBuilder : MonoBehaviour
{
    [SerializeField] List<Pair<UnitJob, Sprite>> JobSpritePairHandAssign;
    Dictionary<UnitJob, Sprite> JobSpriteMap;

    [SerializeField] GameObject m_unitStandPrefab;
    [SerializeField] Transform m_standPoint;
    private void Awake()
    {
        JobSpriteMap = Auxiliary.ListPair2Dictionary<UnitJob, Sprite>(JobSpritePairHandAssign);
        Auxiliary.CheckInspectorNotAssign(m_unitStandPrefab);
    }

    public GameObject BuildUnitGFX(Unit unit)
    {
        GameObject unitGO = Instantiate(m_unitStandPrefab,m_standPoint);
        UnitGFX unitGFX = unitGO.GetComponent<UnitGFX>();
        unitGFX.SR.sprite = JobSpriteMap[unit.Stat.job];

        return unitGO;
    }
}
