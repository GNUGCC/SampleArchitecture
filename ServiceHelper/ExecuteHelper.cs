namespace ServiceHelper;

public static class ExecuteHelper
{
    public static Task Assert(Action action)
    {
        return Assert(() =>
        {
            action.Invoke();
            return Task.CompletedTask;
        });
    }

    public static Task Assert(Func<Task> action)
    {
        return DebugAssert(async () =>
        {
            await action.Invoke();
            return Task.CompletedTask;
        });
    }

    public static Task<TResult> Assert<TResult>(Func<Task<TResult>> action)
    {
        return DebugAssert(action);
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
        return DebugAssert(() => action.Invoke(context));
    }

    static async Task<TResult> DebugAssert<TResult>(Func<Task<TResult>> action)
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
}