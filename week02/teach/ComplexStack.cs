using System;
using System.Collections.Generic;

public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();

        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')' or ']' or '}') {
                if (stack.Count == 0) return false;
                var open = stack.Pop();
                if ((item == ')' && open != '(') ||
                    (item == ']' && open != '[') ||
                    (item == '}' && open != '{'))
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
