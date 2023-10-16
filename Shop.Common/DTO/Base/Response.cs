namespace Shope.Common.DTO.Base;

public class Response<TData>
{
    public Response()
    {
    }
    public Response(TData data,bool _IsSucces,string _Message)
    {
        Message = _Message;
        IsSucces = _IsSucces;
        Data = data;
    }
    public Response(TData data,bool _IsSucces)
    {
        IsSucces = _IsSucces;
        Data = data;
    }
    public Response(TData data)
    {
        Data = data;
        IsSucces = true;
    }
    public bool IsSucces{ get; set; }
    public string? Message{ get; set; }
    public TData Data { get; set; }
}

// public class Response
// {
//     public Response(bool _IsSucces,string _Message)
//     {
//         Message = _Message;
//         IsSucces = _IsSucces;
//     }
//     public Response(bool _IsSucces)
//     {
//         IsSucces = _IsSucces;
//     }
//     public Response()
//     {
//         IsSucces = true;
//     }
//     public bool IsSucces{ get; set; }
//     public string? Message{ get; set; }
// }