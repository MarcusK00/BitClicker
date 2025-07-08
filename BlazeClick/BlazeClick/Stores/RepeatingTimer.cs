using System;
using System.Timers;
using Microsoft.AspNetCore.Components;

public class RepeatingTimer : IDisposable
{
    private System.Timers.Timer _timer;
    private readonly Func<Task> _callback;

    public RepeatingTimer(Func<Task> callback, double intervalMilliseconds = 1000)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        _timer = new System.Timers.Timer(intervalMilliseconds);
        _timer.Elapsed += TimerElapsed;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private async void TimerElapsed(object? sender, ElapsedEventArgs e)
    {
        await _callback.Invoke();
    }

    public void Dispose()
    {
        if (_timer != null)
        {
            _timer.Elapsed -= TimerElapsed;
            _timer.Dispose();
            _timer = null!;
        }
    }
}
