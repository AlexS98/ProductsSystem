namespace ProductSystem.Management.Database.Repository
{
    public class RepositoryOperationResult<T> : RepositoryOperationResult
    {
        public RepositoryOperationResult(T data, bool success = true, string message = null) 
            : base(success, message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }

    public class RepositoryOperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public RepositoryOperationResult(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}