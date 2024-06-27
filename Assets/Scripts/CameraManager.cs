using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public interface ICameraManager
{
    public void CameraHover(Transform @transform);
    public void RessetCamera();
}
public class CameraManager : MonoBehaviour, ICameraManager
{

    [SerializeField] private CinemachineVirtualCamera _mainCam;
    [SerializeField] private Transform _default;


    [Header("Zoom")]
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _zoomLensSize;
    [SerializeField] private float _defaultLensSize;
    private float _targetLensSize;

    private void Awake()
    {
        _targetLensSize = _defaultLensSize;
    }

    public void CameraHover(Transform @transform)
    {
        _targetLensSize = _zoomLensSize;
        _mainCam.Follow = @transform;
    }

    public void RessetCamera()
    {
        _targetLensSize = _defaultLensSize;
        _mainCam.Follow = _default;
    }

    private void FixedUpdate()
    {
        float curSize = _mainCam.m_Lens.OrthographicSize;
        if(curSize != _targetLensSize)
            _mainCam.m_Lens.OrthographicSize = Mathf.Lerp(curSize, _targetLensSize, _zoomSpeed * Time.fixedDeltaTime);
    }

}
