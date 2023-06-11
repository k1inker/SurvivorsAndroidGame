using NTC.Global.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class StageEventManager : MonoBehaviour
{
    [Inject] private Camera _mainCamera;
    [Inject] private DiContainer _container;

    [SerializeField] private List<StageEvent> stageEvents;

    private float _time;
    private float _offset = 3f;
    private int _eventIndexer = 0;
    private int counterSpawnEnemy;

    public Action<float> OnTimeChange;
    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
        OnTimeChange(_time);

        if (_eventIndexer >= stageEvents.Count)
            return;

        if(_time > stageEvents[_eventIndexer].time)
        {
            counterSpawnEnemy = stageEvents[_eventIndexer].countEnemy;
            // logic repeated event
            if(stageEvents[_eventIndexer].isRepeatedEvent && stageEvents[_eventIndexer].countRepeat > 0)
            {
                float timeNextEvent = stageEvents[_eventIndexer].time + stageEvents[_eventIndexer].reapeatEverySeconds;
                // check if repeat event last in List
                if (_eventIndexer + 1 >= stageEvents.Count)
                {
                    stageEvents.Add(CreateNewStage(timeNextEvent));
                }
                else
                {
                    for (int i = _eventIndexer + 1; i < stageEvents.Count; i++)
                    {
                        if (stageEvents[i].time >= timeNextEvent)
                        {
                            stageEvents.Insert(i, CreateNewStage(timeNextEvent));
                            break;
                        }
                    }
                }
            }
            _eventIndexer += 1;
        }
    }
    private StageEvent CreateNewStage(float timeNextEvent)
    {
        int countRepeat = stageEvents[_eventIndexer].countRepeat - 1;
        StageEvent newStage = new StageEvent(timeNextEvent, stageEvents[_eventIndexer].enemyType,
            stageEvents[_eventIndexer].countEnemy, stageEvents[_eventIndexer].isRepeatedEvent,
            stageEvents[_eventIndexer].reapeatEverySeconds, countRepeat);
        return newStage;
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
        NightPool.Spawn(stageEvents[_eventIndexer - 1].enemyType, _container, spawnPosition, Quaternion.identity);
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
