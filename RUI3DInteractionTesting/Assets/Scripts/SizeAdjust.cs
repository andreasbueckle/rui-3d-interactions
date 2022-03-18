using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeAdjust : MonoBehaviour
{
    [SerializeField] private GameObject m_OuterProbingCube;
    [SerializeField] private float m_CubeSize = .01f;
    [SerializeField] private float m_SizeAdjustment = .01f;
    [SerializeField] private Button m_ResetButton;
    void OnEnable()
    {
        UserInputHandler.MouseScrollEvent += AdjustSize;
    }

    void OnDestroy()
    {
        UserInputHandler.MouseScrollEvent -= AdjustSize;
    }

    void Start()
    {
        m_ResetButton.onClick.AddListener(
            delegate { ResetSize(); });
    }

    void ResetSize()
    {
        m_OuterProbingCube.transform.localScale = new Vector3(1, 1, 1);
    }

    void AdjustSize(float value)
    {
        float newsize = m_OuterProbingCube.transform.localScale.x + value * m_SizeAdjustment;
        m_OuterProbingCube.transform.localScale = new Vector3(newsize, newsize, newsize);
    }

}
