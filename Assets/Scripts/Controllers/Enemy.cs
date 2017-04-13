using UnityEngine;
using System.Collections;

// O inimigo, assim como player, implementa as interfaces IShip e ITarget
public class Enemy : MonoBehaviour, IShip, ITarget
{
    public int Damage;
    public GameObject Projectile;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerable Fire()
    {
        var clone = Instantiate(Projectile, transform.position, Quaternion.identity);
        clone.Send<IProjectile>(_ => _.SetData(Damage, false));
        yield return null;
    }

    public IEnumerable Move(float x, float y)
    {
        // TODO: Aqui seria implementada a chamadad da IA do inimigo
        yield return null;
    }

    public IEnumerable GetHit(int damage)
    {
        Destroy(gameObject);
        yield return null;
    }
}
