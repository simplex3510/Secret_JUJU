using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    public void UpdateData(GameObject mainGameObject);

    public void SetMainButtonData(GameObject mainGameObject);
}
