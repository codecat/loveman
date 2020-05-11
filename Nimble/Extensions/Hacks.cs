using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Nimble.Extensions.Hacks
{
  /// <summary>
  /// Class that extends the object class with methods that allow you to interact with private members of said objects.
  /// </summary>
  public static class Hacks
  {
    // Helpers
    private static FieldInfo hackFieldInfoStatic(Type type, string name)
    {
      var fi = type.GetField(name, (BindingFlags)65535);
      if (fi != null) {
        return fi;
      }
      if (type.BaseType != null) {
        return hackFieldInfoStatic(type.BaseType, name);
      }
      return null;
    }
    private static PropertyInfo hackPropertyInfoStatic(Type type, string name)
    {
      var pi = type.GetProperty(name, (BindingFlags)65535);
      if (pi != null) {
        return pi;
      }
      if (type.BaseType != null) {
        return hackPropertyInfoStatic(type.BaseType, name);
      }
      return null;
    }
    private static MethodInfo hackMethodInfoStatic(Type type, string name)
    {
      var mi = type.GetMethod(name, (BindingFlags)65535);
      if (mi != null) {
        return mi;
      }
      if (type.BaseType != null) {
        return hackMethodInfoStatic(type.BaseType, name);
      }
      return null;
    }
    private static FieldInfo hackFieldInfo(this object obj, string name) { return hackFieldInfoStatic(obj.GetType(), name); }
    private static PropertyInfo hackPropertyInfo(this object obj, string name) { return hackPropertyInfoStatic(obj.GetType(), name); }
    private static MethodInfo hackMethodInfo(this object obj, string name) { return hackMethodInfoStatic(obj.GetType(), name); }



    // Fields
    public static void HackSetField(this object obj, string name, object value)
    {
      FieldInfo fi = obj.hackFieldInfo(name);
      if (fi != null) fi.SetValue(obj, value);
    }

    public static object HackGetField(this object obj, string name)
    {
      FieldInfo fi = obj.hackFieldInfo(name);
      if (fi != null) return fi.GetValue(obj);
      return null;
    }



    // Static fields
    public static void HackSetFieldStatic(Type type, string name, object value)
    {
      FieldInfo fi = hackFieldInfoStatic(type, name);
      if (fi != null) fi.SetValue(null, value);
    }

    public static object HackGetFieldStatic(Type type, string name)
    {
      FieldInfo fi = hackFieldInfoStatic(type, name);
      if (fi != null) return fi.GetValue(null);
      return null;
    }



    // Static properties
    public static void HackSetPropertyStatic(Type type, string name, object value)
    {
      PropertyInfo pi = hackPropertyInfoStatic(type, name);
      if (pi != null) pi.SetValue(null, value, null);
    }

    public static void HackSetPropertyStatic(Type type, string name, object value, object index)
    {
      PropertyInfo pi = hackPropertyInfoStatic(type, name);
      if (pi != null) pi.SetValue(null, value, new object[] { index });
    }

    public static void HackSetPropertyStatic(Type type, string name, object value, object[] index)
    {
      PropertyInfo pi = hackPropertyInfoStatic(type, name);
      if (pi != null) pi.SetValue(null, value, index);
    }

    public static object HackGetPropertyStatic(Type type, string name)
    {
      PropertyInfo pi = hackPropertyInfoStatic(type, name);
      if (pi != null) return pi.GetValue(null, null);
      return null;
    }

    public static object HackGetPropertyStatic(Type type, string name, object index)
    {
      PropertyInfo pi = hackPropertyInfoStatic(type, name);
      if (pi != null) return pi.GetValue(null, new object[] { index });
      return null;
    }

    public static object HackGetPropertyStatic(Type type, string name, object[] index)
    {
      PropertyInfo pi = hackPropertyInfoStatic(type, name);
      if (pi != null) return pi.GetValue(null, index);
      return null;
    }



    // Static methods
    public static object HackCallMethodStatic(Type type, string name, params object[] args)
    {
      MethodInfo mi = hackMethodInfoStatic(type, name);
      if (mi != null) return mi.Invoke(null, args);
      return null;
    }



    // Properties
    public static void HackSetProperty(this object obj, string name, object value)
    {
      PropertyInfo pi = obj.hackPropertyInfo(name);
      if (pi != null) pi.SetValue(obj, value, null);
    }

    public static void HackSetProperty(this object obj, string name, object value, object index)
    {
      PropertyInfo pi = obj.hackPropertyInfo(name);
      if (pi != null) pi.SetValue(obj, value, new object[] { index });
    }

    public static void HackSetProperty(this object obj, string name, object value, object[] index)
    {
      PropertyInfo pi = obj.hackPropertyInfo(name);
      if (pi != null) pi.SetValue(obj, value, index);
    }

    public static object HackGetProperty(this object obj, string name)
    {
      PropertyInfo pi = obj.hackPropertyInfo(name);
      if (pi != null) return pi.GetValue(obj, null);
      return null;
    }

    public static object HackGetProperty(this object obj, string name, object index)
    {
      PropertyInfo pi = obj.hackPropertyInfo(name);
      if (pi != null) return pi.GetValue(obj, new object[] { index });
      return null;
    }

    public static object HackGetProperty(this object obj, string name, object[] index)
    {
      PropertyInfo pi = obj.hackPropertyInfo(name);
      if (pi != null) return pi.GetValue(obj, index);
      return null;
    }



    // Methods
    public static object HackCallMethod(this object obj, string name, params object[] args)
    {
      MethodInfo mi = obj.hackMethodInfo(name);
      if (mi != null) return mi.Invoke(obj, args);
      return null;
    }
  }
}
