namespace Asteroids.Model
{
    public interface IEnemyVisitor
    {
        void Visit(Enemy enemy);
        void Visit(Asteroid asteroid);
        void Visit(ArmyEnemy armyEnemy);
        void Visit(PartOfAsteroid nlo);
    }
}
