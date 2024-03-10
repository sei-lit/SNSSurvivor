public interface IDamagable
{
    int CalculateDamage(float intelligence, float assets);
    void AddDamage(int damage);
    int GetHp();
    bool IsDead();
}