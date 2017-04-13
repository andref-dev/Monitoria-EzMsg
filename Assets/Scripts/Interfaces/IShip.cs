using System.Collections;
using UnityEngine.EventSystems;

public interface IShip : IEventSystemHandler
{
    IEnumerable Fire();
    IEnumerable Move(float x, float y);
}
