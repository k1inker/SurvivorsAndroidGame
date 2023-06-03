using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class StageEventManager : MonoBehaviour
{
    [Inject] private Camera _mainCamera;
    [Inject] private DiContainer _container;

    [SerializeField] private StageData _stageData;

    private int _eventIndexer;
    private float _time;
    private float _offset = 3f;

    public Action<float> OnTimeChange; 
    private void FixedUpdate()
    {
        if (_eventIndexer >= _stageData.stageEvents.Count)
            return;

        _time += Time.fixedDeltaTime;
        OnTimeChange(_time);

        if(_time > _stageData.stageEvents[_eventIndexer].time)
        {
            SpawnRandomPositionOutsideScreen();
            _eventIndexer += 1;
        }
    }
    private void SpawnRandomPositionOutsideScreen()
    {
        for (int i = 0; i < _stageData.stageEvents[_eventIndexer].countEnemy; i++)
        {
            Vector3 spawnPosition = GetRandomSidePosition(Random.Range(0, 4), _mainCamera);
            _container.InstantiatePrefab(_stageData.stageEvents[_eventIndexer].enemyType, spawnPosition, Quaternion.identity, null);
        }
    }
    private Vector3 GetRandomSidePosition(int choice, Camera mainCamera)
    {

        float cameraLeftBorderPoint = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, mainCamera.nearClipPlane)).x;
        float cameraTopBorderPoint = mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, mainCamera.nearClipPlane)).y;
        float cameraDownBorderPoint = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, mainCamera.nearClipPlane)).y;
        float cameraRightBorderPoint = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, mainCamera.nearClipPlane)).x;

        float x = 0, y = 0;
        if (choice == 0) // spawn left
        {
            x = Random.Range(cameraLeftBorderPoint - _offset, cameraLeftBorderPoint);
            y = Random.Range(cameraDownBorderPoint - _offset, cameraTopBorderPoint + _offset);
        }
        else if (choice == 1) // spawn top
        {
            x = Random.Range(cameraLeftBorderPoint - _offset, cameraRightBorderPoint + _offset);
            y = Random.Range(cameraTopBorderPoint, cameraTopBorderPoint + _offset);
        }
        else if (choice == 2) // spawn right
        {
            x = Random.Range(cameraRightBorderPoint, cameraRightBorderPoint + _offset);
            y = Random.Range(cameraDownBorderPoint - _offset, cameraTopBorderPoint + _offset);
        }
        else if (choice == 3) // spawn down
        {
            x = Random.Range(cameraLeftBorderPoint - _offset, cameraRightBorderPoint + _offset);
            y = Random.Range(cameraDownBorderPoint - _offset, cameraDownBorderPoint);
        }

        return new Vector3(x, y, 0f);
    }
}
