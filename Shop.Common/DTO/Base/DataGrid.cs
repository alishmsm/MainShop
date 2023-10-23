namespace Shope.Common.DTO.Base;

public class DataGrid<TData>
{

    public DataGrid(TData data,int totalCount)
    {
        Data = data;
        TotalCount = totalCount;
    }
    public int TotalCount { get; set; }
    public TData Data { get; set; }
 
}