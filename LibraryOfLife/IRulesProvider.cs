namespace LibraryOfLife
{
    public interface IRulesProvider
    {
        Coordinate MakeCoordinate(params object[] parts);
        ICell DefaultCell { get; }
        ICell GetNextGeneration(ICell central, params ICell[] adjacentCells);
    }
}
