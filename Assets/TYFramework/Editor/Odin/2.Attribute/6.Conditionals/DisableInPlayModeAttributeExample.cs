﻿using Sirenix.OdinInspector;
using UnityEngine;

public class DisableInPlayModeAttributeExample : MonoBehaviour
{
    [Title("运行模式下禁用属性")]
    [DisableInPlayMode]
    public int A;

    [DisableInPlayMode]
    public Material B;
}
