namespace Core.Infrastructure
{
    public interface IValidator<in T>
    {
        public Result Validate(T dto);
    }
}