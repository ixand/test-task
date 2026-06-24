# FindPath — Shortest Path in a 2D Grid

A C# solution for finding the shortest path in a 2D integer array from `(0,0)` to `(n-1, n-1)` using BFS.

## Problem

Given an `n×n` grid of integers, find the shortest path from the top-left corner to the bottom-right corner under the following movement rules:

- The path may only traverse cells containing **at most two distinct digit types** (e.g. `0` and `5`).
- From a **zero** cell: movement is restricted to **up, down, left, right** (no diagonals).
- From a **non-zero** cell: movement is allowed in **all 8 directions** including diagonals.

## Project Structure

```
FindPath/
├── FindPath.App/
│   └── Program.cs          # BFS implementation + demo entry point
├── FindPath.Tests/
│   └── SampleTests.cs      # NUnit unit tests
└── FindPath.sln
```

## Algorithm

The solution uses **Breadth-First Search (BFS)** to guarantee the shortest path:

1. Start from `(0,0)`, enqueue it.
2. For each cell, check all valid neighbours based on movement rules.
3. Track visited cells and reconstruct the path once `(n-1, n-1)` is reached.
4. Returns an empty array if no path exists.

## Movement Rules Summary

| Current cell | Neighbour cell | Allowed directions |
|---|---|---|
| `0` | any | up, down, left, right |
| non-zero | `0` | up, down, left, right |
| non-zero | non-zero | all 8 directions |

## Requirements

- .NET 6.0+
- NUnit (for tests)

## Running

```bash
dotnet run --project FindPath.App
```

## Tests

```bash
dotnet test FindPath.Tests
```

Three test cases are included:

| Test | Description |
|------|-------------|
| `FindShortestPath_Emptystatic_array` | All-zero grid — expects straight horizontal then vertical path |
| `FindShortestPath_Uniformstatic_array` | All non-zero grid — expects diagonal path |
| `FindShortestPath_Mixedstatic_array` | Mixed grid — expects shortest diagonal path through non-zero cells |
