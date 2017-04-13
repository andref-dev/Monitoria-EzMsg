using System.Collections;
using UnityEngine.EventSystems;

public interface IProjectile : IEventSystemHandler
{
    IEnumerable SetData(int damage, bool isPlayer);
}
