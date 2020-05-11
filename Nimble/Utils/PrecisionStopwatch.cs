using System;
using System.Runtime.InteropServices;

namespace Nimble.Utils
{
  /// <summary>
  /// High precision stopwatch, able to measure time in microseconds.
  /// </summary>
  public class HPStopwatch
  {
    [DllImport("kernel32.dll")]
    extern static short QueryPerformanceCounter(ref long x);
    [DllImport("kernel32.dll")]
    extern static short QueryPerformanceFrequency(ref long x);

    private long StartTime;
    private long StopTime;
    private long ClockFrequency;
    private long CalibrationTime;

    public HPStopwatch()
    {
      StartTime = 0;
      StopTime = 0;
      ClockFrequency = 0;
      CalibrationTime = 0;
      Calibrate();
    }

    private void Calibrate()
    {
      QueryPerformanceFrequency(ref ClockFrequency);

      for (int i = 0; i < 1000; i++) {
        Start();
        Stop();
        CalibrationTime += StopTime - StartTime;
      }

      CalibrationTime /= 1000;
    }

    /// <summary>
    /// Reset the timer.
    /// </summary>
    public void Reset()
    {
      StartTime = 0;
      StopTime = 0;
    }

    /// <summary>
    /// Start the timer.
    /// </summary>
    public void Start()
    {
      QueryPerformanceCounter(ref StartTime);
    }

    /// <summary>
    /// Stop the timer.
    /// </summary>
    public void Stop()
    {
      QueryPerformanceCounter(ref StopTime);
    }

    /// <summary>
    /// Get the elapsed timespan after the timer got stopped.
    /// </summary>
    /// <returns>Elapsed time.</returns>
    public TimeSpan GetElapsedTimeSpan()
    {
      return TimeSpan.FromMilliseconds(_GetElapsedTime_ms());
    }

    /// <summary>
    /// Get the elapsed timespan while the timer is still running.
    /// </summary>
    /// <returns>Elapsed time.</returns>
    public TimeSpan GetSplitTimeSpan()
    {
      return TimeSpan.FromMilliseconds(_GetSplitTime_ms());
    }

    /// <summary>
    /// Get the elapsed amount of microseconds after the timer got stopped.
    /// </summary>
    /// <returns></returns>
    public double GetElapsedTimeInMicroseconds()
    {
      return (((StopTime - StartTime - CalibrationTime) * 1000000.0 / ClockFrequency));
    }

    /// <summary>
    /// Get the elapsed amount of microseconds while the timer is still running.
    /// </summary>
    /// <returns></returns>
    public double GetSplitTimeInMicroseconds()
    {
      long current_count = 0;
      QueryPerformanceCounter(ref current_count);
      return (((current_count - StartTime - CalibrationTime) * 1000000.0 / ClockFrequency));
    }

    private double _GetSplitTime_ms()
    {
      long current_count = 0;
      QueryPerformanceCounter(ref current_count);
      return (((current_count - StartTime - CalibrationTime) * 1000000.0 / ClockFrequency) / 1000.0);
    }

    private double _GetElapsedTime_ms()
    {
      return (((StopTime - StartTime - CalibrationTime) * 1000000.0 / ClockFrequency) / 1000.0);
    }
  }
}
