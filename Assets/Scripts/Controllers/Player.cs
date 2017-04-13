using UnityEngine;
using System.Collections;

// O componente Player implementa as interfaces IShip e ITarget
public class Player : MonoBehaviour, IShip, ITarget
{
    public GameObject Projectile;
    public int Damage;
    public float MoveSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	    /*
         Essa lógica de input poderia ficar em qualquer lugar do codigo
	     que tenha acesso a esse gameobject isso é o ideal pois existe
	     apenas um cérebro que pega o input, e entao espalha para o resto do jogo
        */
	    if (Input.GetKey(KeyCode.LeftArrow))
	    {
	        gameObject.Send<IShip>(ship => ship.Move(-MoveSpeed, 0));
	    }
	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        gameObject.Send<IShip>(ship => ship.Move(MoveSpeed, 0));
	    }
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        gameObject.Send<IShip>(ship => ship.Fire());
	    }
	}

    public IEnumerable Fire()
    {
        Debug.Log("Fire");
        var clone = Instantiate(Projectile, transform.position, Quaternion.identity);
        clone.Send<IProjectile>(_ => _.SetData(Damage, true));
        yield return null;
    }

    public IEnumerable Move(float x, float y)
    {
        Debug.Log("Move");
        var pos = transform.position;
        pos.x += x * Time.deltaTime;
        pos.y += y * Time.deltaTime;
        transform.position = pos;
        yield return null;
    }

    public IEnumerable GetHit(int damage)
    {
        Debug.Log("GetHit");
        Destroy(gameObject);
        yield return null;
    }
}
