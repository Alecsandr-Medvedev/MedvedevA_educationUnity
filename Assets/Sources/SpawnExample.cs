using UnityEngine;
using Asteroids.Model;
using System.Collections.Generic;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;

    private int _index;
    private float _secondsPerIndex = 1f;


    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }

    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 20)
        {
            Vector2 positionEnemy1 = GetRandomPositionLeftScreen();
            Vector2 positionEnemy2 = GetRandomPositionRightScreen();
            Vector2 position = (positionEnemy1 + positionEnemy2) / 2;
            ArmyEnemy enemy1 = new ArmyEnemy(position, positionEnemy1, 0.076f);
            ArmyEnemy enemy2 = new ArmyEnemy(position, positionEnemy2, 0.077f);
            enemy1.setTarget(enemy2);
            enemy2.setTarget(enemy1);
            _factory.CreateNegativeNlo(enemy1);
            _factory.CreateNlo(enemy2);
        }
        else
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }

    private Vector2 GetRandomPositionLeftScreen()
    {
        return new Vector2(-0.1f, Random.Range(0.1f, 0.9f));
    }

    private Vector2 GetRandomPositionRightScreen()
    {
        return new Vector2(1.1f, Random.Range(0.1f, 0.9f));
    }
}
