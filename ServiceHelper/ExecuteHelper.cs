namespace ServiceHelper;

public static class ExecuteHelper
{
    public static Task Assert(Func<Task> action)
    {
        return Assert(async () =>
        {
            await action.Invoke();
            return Task.CompletedTask;
        });
    }

    public static async Task<TResult> Assert<TResult>(Func<Task<TResult>> action)
    {
        try
        {
            return await action.Invoke();
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public static Task Assert<T>(T context, Func<T, Task> action)
    {
        return Assert(context, async x =>
        {
            await action.Invoke(context);
            return Task.CompletedTask;
        });
    }

    public static Task<TResult> Assert<T, TResult>(T context, Func<T, Task<TResult>> action)
    {
        return Assert(() => action.Invoke(context));
    }
}