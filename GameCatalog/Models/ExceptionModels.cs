namespace GameCatalog.Models
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }
    }

    public class DuplicateItemException : Exception
    {
        public DuplicateItemException() : base() { }
        public DuplicateItemException(string message) : base(message) { }
        public DuplicateItemException(string message, Exception inner) : base(message, inner) { }
    }
}
