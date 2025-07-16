using TMPro;
using UnityEngine;

public class DevModeUnitUIHandler : MonoBehaviour
{
    Unit m_rUnit;

    [SerializeField] TMP_Text m_name;
    [SerializeField] TMP_Text m_job;
    [SerializeField] TMP_Text m_grade;

    public Unit rUnit
    {
        set
        {
            m_rUnit = value;
            UpdateTexts();
        }
    }
    void UpdateTexts()
    {
        m_name.text = m_rUnit.Name;
        m_job.text = m_rUnit.Stat.job.ToString();
        m_grade.text = m_rUnit.Stat.grade.ToString();
    }
}
