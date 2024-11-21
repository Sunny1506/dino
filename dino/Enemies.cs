
public class Enemies
{
    List<Enemy> enemies = new List<Enemy>();
    Enemy atual = null;
    double minX = 0;
    public Enemies(double a)
    {
        minX = a;
    }
    public void Add(Enemy a)
    {
        enemies.Add(a);
        if (atual == null)
            atual = a;
        Iniciar();
    }
    public void Iniciar()
    {
        foreach (var e in enemies)
            e.Reset();
    }
    void Gerencia()
    {
        if (atual.GetX() < minX)
        {
            Iniciar();
            var r = Random.Shared.Next(0, enemies.Count);
            atual = enemies[r];
        }
    }
    public void Desenha(int veloc)
    {
        atual.MoveX(veloc);
        Gerencia();
    }
}