// <copyright file="Edge.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// A class for representing graph edges.
/// </summary>
public record Edge(int Start, int End, int Weight);