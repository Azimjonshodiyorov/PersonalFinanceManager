namespace PersonalFinance.Application.ViewModel.Response.CommandResponse;

public class Response
{
    public bool Success { get; set; }
    public object Data { get; set; }
    public object Error { get; set; }

    public Response()
    {
    }

    public Response(bool success , object data , object error)
    {
        Success = success;
        Data = data;
        Error = error;
    }
}