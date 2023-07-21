using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubjectable
{

    void ResisterObserver(IObservable observer);

    void RemoveObserver(IObservable observer);

    void NotifyObservers();

    void ReceiveObservers(GameObject mainGameObject);

}
