using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LessonOneTaskThree))]
public class LessonOneTaskThreeEditor : Editor
{
    #region [ Fields ]
    private LessonOneTaskThree _target;
    private SerializedProperty _stringInputOneProp;
    private SerializedProperty _stringInputTwoProp;
    private SerializedProperty _stringOutputProp;
    private SerializedProperty _intInputOneProp;
    private SerializedProperty _intInputTwoProp;
    private SerializedProperty _intOutputProp;
    #endregion
    
    #region [ UXML ]
    private VisualElement _root;
    private Label _taskCompletedLabel;
    private Label _variableDisplayLabel;
    #endregion
    
    

    private void OnEnable()
    {
        _stringInputOneProp = serializedObject.FindProperty("stringInputOne");
        _stringInputTwoProp = serializedObject.FindProperty("stringInputTwo");
        _stringOutputProp = serializedObject.FindProperty("stringOutput");
        _intInputOneProp = serializedObject.FindProperty("integerInputOne");
        _intInputTwoProp = serializedObject.FindProperty("integerInputTwo");
        _intOutputProp = serializedObject.FindProperty("integerOutput");
    }
    
    public override bool UseDefaultMargins() => false;
    public override VisualElement CreateInspectorGUI()
    {
        _target = target as LessonOneTaskThree;
        
        _root = LoadVisualTreeAssetAndGetRoot();
        RegisterElements();

        SetDefaultValues();
        _root.schedule.Execute(UpdateUI).Every(200);
        
        return _root;
    }
    
    private VisualElement LoadVisualTreeAssetAndGetRoot()
    {
        VisualTreeAsset taskUI = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UXML/Lesson 1 Task 3.uxml"); 
        _root = taskUI.CloneTree();
        
        return _root;
    }

    private void RegisterElements()
    {
        _taskCompletedLabel = _root.Q<Label>("TaskCompletedLabel");
        _variableDisplayLabel = _root.Q<Label>("VariableDisplayLabel");
    }

    private void SetDefaultValues()
    {
        serializedObject.Update();
        
        _stringOutputProp.stringValue = "";
        _intOutputProp.intValue = 0;
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void UpdateUI()
    {
        serializedObject.Update();

        _variableDisplayLabel.text =
            "String Combination\n" +
            $"      Input 1: <color=#c1f2eb>{_stringInputOneProp.stringValue}</color> \n" +
            $"      Input 2: <color=#c1f2eb>{_stringInputTwoProp.stringValue}</color> \n" +
            $"      Output: <color=#c1f2eb>{_stringOutputProp.stringValue}</color> \n" + 
            "Integer Addition\n" +
            $"      Input 1: <color=#c1f2eb>{_intInputOneProp.intValue}</color> \n" +
            $"      Input 2: <color=#c1f2eb>{_intInputTwoProp.intValue}</color> \n" +
            $"      Output: <color=#c1f2eb>{_intOutputProp.intValue}</color> \n";
        
        bool combinedStringPresent = _stringOutputProp.stringValue == _stringInputOneProp.stringValue + _stringInputTwoProp.stringValue;
        bool intSummationPresent = _intOutputProp.intValue == _intInputOneProp.intValue + _intInputTwoProp.intValue;
        bool taskCompleted = combinedStringPresent && intSummationPresent;
        
        _taskCompletedLabel.text = taskCompleted ? 
            "Task Completed: <color=#b2f759>True</color>" : 
            "Task Completed: <color=#f96c4f>False</color>";
    }
}
