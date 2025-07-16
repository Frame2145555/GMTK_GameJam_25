using UnityEngine;
using TMPro;

public class DevModeObjectiveUI : MonoBehaviour
{
    [SerializeField] TMP_Text m_jobText;
    [SerializeField] TMP_Text m_gradeText;
    [SerializeField] TMP_Text m_countText;

    public TMP_Text JobText { get => m_jobText; }
    public TMP_Text GradeText { get => m_gradeText; }
    public TMP_Text CountText { get => m_countText; }

    private void Awake()
    {
        Auxiliary.CheckInspectorNotAssign(m_jobText);
        Auxiliary.CheckInspectorNotAssign(m_gradeText);
        Auxiliary.CheckInspectorNotAssign(m_countText);
    }
}
