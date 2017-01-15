// Solution Name: FGF
// Project: FGF
// File: IHandle.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System;
using JetBrains.Annotations;

public interface IHandle<T> {
    void Handle(T argument);
}