using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private CubeClickHandler _cubeClickHandler;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) == false)
            {
                return;
            }  
            
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                _cubeClickHandler.OnCubeClick(cube);
            }
        }
    }
}