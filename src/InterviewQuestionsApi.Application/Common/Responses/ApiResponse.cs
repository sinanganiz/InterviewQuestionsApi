namespace InterviewQuestionsApi.Application.Common.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public static ApiResponse<T> SuccessResponse(T data, string message = null) =>
        new() { Success = true, Data = data, Message = message };

    public static ApiResponse<T> Failure(string message) =>
        new() { Success = false, Data = default, Message = message };

}