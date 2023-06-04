using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class StageEventManager : MonoBehaviour
{
    [Inject] private Camera _mainCamera;
    [Inject] private DiContainer _container;

    [SerializeField] private float progressTimeRate = 30f;
    [SerializeField] private float progressPerSplit = .2f;
    [SerializeField] private List<StageEvent> stageEvents;
    private int _eventIndexer;
    private float _time;
    private float _offset = 3f;
    private int counterSpawnEnemy;

    public Action<float> OnTimeChange;
    private float _progress
    {
        get
        {
            return _time / progressTimeRate * progressPerSplit;
        }
    }
    private void FixedUpdate()
    {
        if (_eventIndexer >= stageEvents.Count)
            return;

        _time += Time.fixedDeltaTime;
        OnTimeChange(_time);

        if(_time > stageEvents[_eventIndexer].time)
        {
            counterSpawnEnemy = stageEvents[_eventIndexer].countEnemy;

            // logic for repeats event
            if (stageEvents[_eventIndexer].isRepeatedEvent)
            {
                if (stageEvents[_eventIndexer].countRepeat != 0)
                {
                    stageEvents[_eventIndexer].time += stageEvents[_eventIndexer].reapeatEverySeconds;

                    // adding new event aftef this index by sorting time
                    int insertIndex = stageEvents.BinarySearch(_eventIndexer + 1, stageEvents.Count - (_eventIndexer + 1), stageEvents[_eventIndexer],
                        Comparer<StageEvent>.Create((a, b) => a.time.CompareTo(b.time)));

                    if (insertIndex < 0)
                    {
                        insertIndex = ~insertIndex;
                    }

                    stageEvents[_eventIndexer].countRepeat--;
                    stageEvents.Insert(insertIndex, stageEvents[_eventIndexer]);
                }
            }
            _eventIndexer += 1;
        }
    }
    private void Update()
    {
        if (counterSpawnEnemy <= 0)
            return;

        SpawnRandomEnemysByStage();
    }

    private void SpawnRandomEnemysByStage()
    {
        Vector3 spawnPosition = GetRandomSidePosition(Random.Range(0, 4), _mainCamera);
        GameObject enemy = _container.InstantiatePrefab(stageEvents[_eventIndexer].enemyType, spawnPosition, Quaternion.identity, null);
        enemy.GetComponent<EnemyStatsManager>().ApplyProgress(_progress);

        counterSpawnEnemy--;
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
