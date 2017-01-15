// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: IHandle.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 05 - 0:16

using System;
using JetBrains.Annotations;

public interface IHandle<T> {
    void Handle(T argument);
}