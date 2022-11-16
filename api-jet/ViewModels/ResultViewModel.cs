namespace api.ViewModels.Result
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(string message, bool success, T data, List<string> errors)
        {
            Message = message;
            Success = success;
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;

        }

        public ResultViewModel(List<string> errors)
        {
            Errors = errors;
        }

        public ResultViewModel(string error)
        {
            Errors.Add(error);
        }

        public string Message { get; set; }
        public bool? Success { get; set; }
        public T Data { get; private set; }

        public List<string> Errors { get; private set; } = new List<string>();



    }
}
