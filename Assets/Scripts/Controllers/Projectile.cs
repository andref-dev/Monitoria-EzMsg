using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour, IProjectile
{
    public int Damage;
    public float MoveSpeed;

    private bool _isPlayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //Move o projetil de acordo com o seu dono
	    var pos = transform.position;
	    pos.y += _isPlayer ? MoveSpeed * Time.deltaTime : -MoveSpeed * Time.deltaTime;
	    transform.position = pos;

	    // Remove projetil se fora da visao da camera
	    if (!Camera.main.OrthographicBounds().Contains(transform.position))
	    {
	        Destroy(gameObject);
	    }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.Send<ITarget>(_=>_.GetHit(Damage));
        Destroy(gameObject);
    }

    public IEnumerable SetData(int damage, bool isPlayer)
    {
        Damage = damage;
        _isPlayer = isPlayer;
        yield return null;
    }
}
