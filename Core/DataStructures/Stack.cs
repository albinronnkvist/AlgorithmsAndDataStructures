namespace Albin.AlgorithmsAndDataStructures.Core.DataStructures;

// Simple example of a bounded Stack implemented with an array of integers for simplicity
// Lib: Stack<T>
public class Stack
{
    private int MaxSize { get; init; }
    private int Top { get; set; }
    private int[] Items { get; set; }

    public Stack(int maxSize)
    {
        MaxSize = maxSize;
        Top = 0;
        Items = new int[MaxSize];
    }

    public void Push(int item)
    {
        if(Top == MaxSize){
            throw new OverflowException();
        }

        Items[Top] = item;
        Top++;
    }

    public int Pop()
    {
        if(Top is 0){
            throw new InvalidOperationException();
        }

        Top--;
        return Items[Top];
    }
}

/*
Stacks stores objects in a sort of vertical tower where the last object that was added is the first object to be fetched (LIFO).

Analogy:
Stacks behaves like a stack of plates, where the last plate added is the first one to be removed.
- Pushing an element onto the stack is like adding a new plate on top.
- Popping an element removes the top plate from the stack.

Use cases:
- Undo/Redo operations
- Browser History
- Function calls
- Depth-first search
*/