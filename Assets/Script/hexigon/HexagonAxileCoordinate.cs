public struct HexagonAxialCoordinates
{
    public readonly int q; // pointing top-right
    public readonly int r; // pointing up

    public HexagonAxialCoordinates(int q, int r)
    {
        this.q = q;
        this.r = r;
    }

    public static HexagonAxialCoordinates FromCardialCoordinates(int x, int y)
    {
        int q = x;
        int r = y - x / 2;
        return new HexagonAxialCoordinates(q, r);
    }
    public static HexagonAxialCoordinates FromOffsetCoordinates(int col, int row)
    {
        int q = col;
        int r = row - col / 2;
        return new HexagonAxialCoordinates(q, r);
    }
    
}
