public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert unique values only
    public void Insert(int value)
    {
        if (value == Data) return; // ignore duplicates

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: Contains (recursive)
    public bool Contains(int value)
    {
        if (value == Data) return true;
        if (value < Data)  return Left != null && Left.Contains(value);
        return Right != null && Right.Contains(value);
    }

    // Problem 4: GetHeight
    public int GetHeight()
    {
        int leftH  = Left  == null ? 0 : Left.GetHeight();
        int rightH = Right == null ? 0 : Right.GetHeight();
        return 1 + System.Math.Max(leftH, rightH);
    }
}
