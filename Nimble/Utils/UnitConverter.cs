using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nimble.Utils
{
  public static class UnitConverter
  {
    public static string BytesToString(ulong ulBytes, bool bFullWords = false, double iBase = 1000)
    {
      if (ulBytes < iBase) return ulBytes + " " + (bFullWords ? "bytes" : "B");
      if (ulBytes < iBase * iBase) return (ulBytes / iBase).ToString("N2") + " " + (bFullWords ? "kilobytes" : "KB");
      if (ulBytes < iBase * iBase * iBase) return (ulBytes / iBase / iBase).ToString("N2") + " " + (bFullWords ? "megabytes" : "MB");
      return (ulBytes / iBase / iBase / iBase).ToString("N2") + " " + (bFullWords ? "gigabytes" : "GB");
    }

    public static string Plural(dynamic count, string single, string multiple)
    {
      return count + " " + (count == 1 ? single : multiple);
    }

    public static string TimeAgo(DateTime oldTime)
    {
      return TimeAgo((long)(oldTime.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds);
    }

    public static string TimeAgo(long oldTime)
    {
      long tmNow = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
      long tmCalc = tmNow - oldTime;
      if (tmCalc >= (60 * 60 * 24)) return Plural(Math.Round(tmCalc / 60.0 / 60.0 / 24.0), "day", "days") + " ago";
      if (tmCalc >= (60 * 60)) return Plural(Math.Round(tmCalc / 60.0 / 60.0), "hour", "hours") + " ago";
      if (tmCalc >= 60) return Plural(Math.Round(tmCalc / 60.0), "minute", "minutes") + " ago";
      return Plural(tmCalc, "second", "seconds") + " ago";
    }
  }
}
