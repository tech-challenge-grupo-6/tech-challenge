namespace Domain;

public interface IValidador<T>
{
    static abstract bool IsValid(T entidade);
}
