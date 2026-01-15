using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    #region [ Serialised Fields ]
    public List<Vector3> positions = new List<Vector3>();
    [SerializeField] private float _floatCycleDuration;
    [SerializeField] private float _floatDisplacement;
    [SerializeField] private float _movementSpeed;
    #endregion

    #region [ Unserialised Fields ]
    private Transform _transform;
    private int _positionIndex;
    private float _positionLerpWeight;
    #endregion

    

    private void Awake() => _transform = transform;

    void Start()
    {
        _positionLerpWeight = 0;
        _positionIndex = 0;
        
        _transform.position = positions[_positionIndex];
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SPACE");
        }
        
        if (positions.Count <= 0) return;
        
        Vector3 positionTargetOne = positions[_positionIndex];
        Vector3 positionTargetTwo = (_positionIndex + 1 < positions.Count) ? positions[_positionIndex + 1] : positions[0];
        Vector3 lerpPosition = Vector3.Lerp(positionTargetOne, positionTargetTwo, _positionLerpWeight);
        
        Vector3 floatOffset = new Vector3(0, Mathf.Sin(Time.timeSinceLevelLoad * (1 / _floatCycleDuration)) * _floatDisplacement, 0);
        Vector3 finalPosition = lerpPosition + floatOffset;
        
        _transform.position = finalPosition;
        
        float distanceBetweenPoints = Vector3.Distance(positionTargetOne, positionTargetTwo);
        float distanceDelta = _movementSpeed * Time.deltaTime;
        
        _positionLerpWeight += distanceDelta / distanceBetweenPoints;
        if (_positionLerpWeight > 1)
        {
            _positionIndex = (_positionIndex + 1 < positions.Count) ? _positionIndex + 1 : 0;
            _positionLerpWeight = 0;
        }
    }
}
