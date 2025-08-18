namespace RecruitmentPortal.Repository.ViewModels;

/// <summary>
/// this class is model view, which is used for api responses
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
}
