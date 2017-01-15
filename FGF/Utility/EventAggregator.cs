// Solution Name: FGF
// Project: FGF
// File: EventAggregator.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System;
using UnityEngine;
using System.Collections;
using UniRx;

public interface IEventAggregator {
    IObservable<TEvent> GetEvent<TEvent>();
    void Publish<TEvent>(TEvent evt);
}

public class EventAggregator : IEventAggregator, ISubject<object> {
    #region Fields
    private readonly Subject<object> eventsSubject = new Subject<object>();
    private bool isDisposed;
    #endregion

    public void Dispose() {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing) {
        if (isDisposed) return;
        eventsSubject.Dispose();
        isDisposed = true;
    }

    public IObservable<TEvent> GetEvent<TEvent>() {
        return eventsSubject.Where(p => { return p is TEvent; }).Select(delegate(object p) { return (TEvent) p; });
    }

    public void Publish<TEvent>(TEvent evt) {
        eventsSubject.OnNext(evt);
    }

    public void OnCompleted() {
        eventsSubject.OnCompleted();
    }

    public void OnError(Exception error) {
        eventsSubject.OnError(error);
    }

    public void OnNext(object value) {
        eventsSubject.OnNext(value);
    }

    public IDisposable Subscribe(IObserver<object> observer) {
        return eventsSubject.Subscribe(observer);
    }
}