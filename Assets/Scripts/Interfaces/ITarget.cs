using System.Collections;
using UnityEngine.EventSystems;

public interface ITarget : IEventSystemHandler
{
    IEnumerable GetHit(int damage);
}
