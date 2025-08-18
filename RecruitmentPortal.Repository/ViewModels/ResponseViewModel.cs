namespace RecruitmentPortal.Repository.ViewModels;

public class ResponseViewModel<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? data { get; set; }
    public List<T>? dataList { get; set; }

}
