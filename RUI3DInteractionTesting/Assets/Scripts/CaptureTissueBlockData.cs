using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTissueBlockData : MonoBehaviour
{
    public delegate void Inventory(List<AnatomicalStructures> uniqueAS, List<CellTypes> uniqueCT);
    public static event Inventory UpdateInventoryEvent;
<<<<<<< Updated upstream
    private List<AnatomicalStructures> m_UniqueAS = new List<AnatomicalStructures>();
    private List<CellTypes> m_UniqueCT = new List<CellTypes>();
=======
    private List<AnatomicalStructures> m_AnatomicalStructures = new List<AnatomicalStructures>();
    private List<CellTypes> m_CellTypes = new List<CellTypes>();
    [SerializeField] private int m_NumberTissueBlocks;
>>>>>>> Stashed changes


    void OnEnable()
    {
        CollisionDetector.CollisionDataEvent += GetTissueBlockData;
    }

    void OnDestroy()
    {
        CollisionDetector.CollisionDataEvent -= GetTissueBlockData;
    }
    // Start is called before the first frame update
    void GetTissueBlockData(TissueBlockData data, bool isCollided)
    {
        // Debug.Log(data.m_ListAS[0]);
        UpdateAS(data.m_ListAS, isCollided);
        UpdateCT(data.m_ListCT, isCollided);
<<<<<<< Updated upstream
=======
        UpdateNumberTissueBlock(isCollided);
        UpdateInventoryEvent?.Invoke(m_AnatomicalStructures, m_CellTypes, m_NumberTissueBlocks);
    }
>>>>>>> Stashed changes

        UpdateInventoryEvent?.Invoke(m_UniqueAS, m_UniqueCT);
    }

    void UpdateAS(List<AnatomicalStructures> list, bool isCollided)
    {
        if (isCollided)
        {
            foreach (var item in list)
            {
                m_AnatomicalStructures.Add(item);
            }

        }
        else
        {
            foreach (var item in list)
            {
                m_AnatomicalStructures.Remove(item);
            }
        }
    }

    void UpdateCT(List<CellTypes> list, bool isCollided)
    {
        if (isCollided)
        {
            foreach (var item in list)
            {
                m_CellTypes.Add(item);
            }

        }
        else
        {
            foreach (var item in list)
            {
                m_CellTypes.Remove(item);
            }
        }
    }


}
