using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Ghost))]
public class GhostEditor : Editor
{
    #region [ Fields ]
    private Ghost _target;
    #endregion
    
    
    
    private void OnEnable()
    {
        _target = (Ghost) target;
    }
    
    private void OnSceneGUI()
    {
        List<Vector3> positions = _target.positions;
        for (int i = 0; i < positions.Count; i++)
        {
            positions[i] = Handles.PositionHandle(positions[i], Quaternion.identity);
            EditorUtility.SetDirty(this);
        }
    }
}
