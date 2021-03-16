using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameeManager : MonoBehaviour
{
    //singleton tasarım kalıbı ile nesneme global erişim noktası sağlıyorum
    #region Singleton class: GameeManager 

    public static GameeManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion //

    [HideInInspector] public bool isGameover = false; // inspectordan görünmesin ama diğer scriptlerden erişebileyim
}
