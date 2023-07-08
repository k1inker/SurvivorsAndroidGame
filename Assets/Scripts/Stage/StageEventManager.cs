using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class StageEventManager : MonoBehaviour
{
    [Inject] private Camera _mainCamera;
    [Inject] private DiContainer _container;

    [SerializeField] private List<RegularEvent> regularStageEvents;
    [SerializeField] private RandomEvent[] randomEvents;
    [SerializeField] private float _randomEventPerSeconds;

    private float _time;
    private float _spawnOffset = 3f;
    private int _eventIndexer = 0;

    public Action<float> OnTimeChange;
    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
        OnTimeChange(_time);
        SwitchingRegularEvent();
        StartRandomEvent();
    }
    private void StartRandomEvent()
    {
        if(_time >= _randomEventPerSeconds)
        {
            _randomEventPerSeconds += _randomEventPerSeconds;
            int idEvent = Random.Range(0, randomEvents.Length - 1);
            randomEvents[idEvent].StartEvent(GetRandomPositions(randomEvents[idEvent].countObject), _container);
        }
    }
    private void SwitchingRegularEvent()
    {
        if (_eventIndexer >= regularStageEvents.Count)
            return;

        if (_time > regularStageEvents[_eventIndexer].time)
        {
            // logic repeated event
            if (regularStageEvents[_eventIndexer].isRepeatedEvent && regularStageEvents[_eventIndexer].countRepeat > 0)
            {
                float timeNextEvent = regularStageEvents[_eventIndexer].time + regularStageEvents[_eventIndexer].reapeatEverySeconds;
                // check if repeat event last in List
                if (_eventIndexer + 1 >= regularStageEvents.Count)
                {
                    regularStageEvents.Add(regularStageEvents[_eventIndexer].CreateNewStage(timeNextEvent));
                }
                else
                {
                    for (int i = _eventIndexer + 1; i < regularStageEvents.Count; i++)
                    {
                        if (regularStageEvents[i].time >= timeNextEvent)
                        {
                            regularStageEvents.Insert(i, regularStageEvents[_eventIndexer].CreateNewStage(timeNextEvent));
                            break;
                        }
                    }
                }
            }
            regularStageEvents[_eventIndexer].StartEvent(GetRandomPositions(regularStageEvents[_eventIndexer].countObject), _container);
            _eventIndexer += 1;
        }
    }
    private Vector3[] GetRandomPositions(int countPositions)
    {
        Vector3[] randomPositions = new Vector3[countPositions];
        for(int i = 0; i < countPositions; i++)
        {
            randomPositions[i] = GetRandomSidePosition(Random.Range(0, 4), _mainCamera);
        }
        return randomPositions;
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
            x = Random.Range(cameraLeftBorderPoint - _spawnOffset, cameraLeftBorderPoint);
            y = Random.Range(cameraDownBorderPoint - _spawnOffset, cameraTopBorderPoint + _spawnOffset);
        }
        else if (choice == 1) // spawn top
        {
            x = Random.Range(cameraLeftBorderPoint - _spawnOffset, cameraRightBorderPoint + _spawnOffset);
            y = Random.Range(cameraTopBorderPoint, cameraTopBorderPoint + _spawnOffset);
        }
        else if (choice == 2) // spawn right
        {
            x = Random.Range(cameraRightBorderPoint, cameraRightBorderPoint + _spawnOffset);
            y = Random.Range(cameraDownBorderPoint - _spawnOffset, cameraTopBorderPoint + _spawnOffset);
        }
        else if (choice == 3) // spawn down
        {
            x = Random.Range(cameraLeftBorderPoint - _spawnOffset, cameraRightBorderPoint + _spawnOffset);
            y = Random.Range(cameraDownBorderPoint - _spawnOffset, cameraDownBorderPoint);
        }

        return new Vector3(x, y, 0f);
    }
}
