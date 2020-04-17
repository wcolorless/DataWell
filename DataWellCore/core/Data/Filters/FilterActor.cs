using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Data.Filters
{
    public class FilterActor
    {
        public static bool Check(FilterType filterType, object obj1, object obj2, string needType)
        {
            var result = false;
            try
            {
                switch (filterType)
                {
                    case FilterType.Equal:
                    {
                        switch (needType)
                        {
                            case "System.String":
                                result = (string)Convert.ChangeType(obj1, typeof(string)) == (string)Convert.ChangeType(obj2, typeof(string));
                                break;
                            case "System.Boolean":
                                result = (bool)Convert.ChangeType(obj1, typeof(bool)) == (bool)Convert.ChangeType(obj2, typeof(bool));
                                break;
                            case "System.Byte":
                                result = (byte)Convert.ChangeType(obj1, typeof(byte)) == (byte)Convert.ChangeType(obj2, typeof(byte));
                                break;
                            case "System.SByte":
                                result = (sbyte)Convert.ChangeType(obj1, typeof(sbyte)) == (sbyte)Convert.ChangeType(obj2, typeof(sbyte));
                                break;
                            case "System.Char":
                                result = (char)Convert.ChangeType(obj1, typeof(char)) == (char)Convert.ChangeType(obj2, typeof(char));
                                break;
                            case "System.Decimal":
                                result = (decimal)Convert.ChangeType(obj1, typeof(decimal)) == (decimal)Convert.ChangeType(obj2, typeof(decimal));
                                break;
                            case "System.Double":
                                result = (double)Convert.ChangeType(obj1, typeof(double)) == (double)Convert.ChangeType(obj2, typeof(double));
                                break;
                            case "System.Single":
                                result = (Single)Convert.ChangeType(obj1, typeof(Single)) == (Single)Convert.ChangeType(obj2, typeof(Single));
                                break;
                            case "System.Int32":
                                result = (int)Convert.ChangeType(obj1, typeof(int)) == (int)Convert.ChangeType(obj2, typeof(int));
                                break;
                            case "System.UInt32":
                                result = (uint)Convert.ChangeType(obj1, typeof(uint)) == (uint)Convert.ChangeType(obj2, typeof(uint));
                                break;
                            case "System.Int64":
                                result = (long)Convert.ChangeType(obj1, typeof(long)) == (long)Convert.ChangeType(obj2, typeof(long));
                                break;
                            case "System.UInt64":
                                result = (ulong)Convert.ChangeType(obj1, typeof(ulong)) == (ulong)Convert.ChangeType(obj2, typeof(ulong));
                                break;
                            case "System.Int16":
                                result = (short)Convert.ChangeType(obj1, typeof(short)) == (short)Convert.ChangeType(obj2, typeof(short));
                                break;
                            case "System.UInt16":
                                result = (ushort)Convert.ChangeType(obj1, typeof(ushort)) == (ushort)Convert.ChangeType(obj2, typeof(ushort));
                                break;
                        }
                    } break;
                    case FilterType.NotEqual:
                    {
                        switch (needType)
                        {
                            case "System.String":
                                result = (string)Convert.ChangeType(obj1, typeof(string)) != (string)Convert.ChangeType(obj2, typeof(string));
                                break;
                            case "System.Boolean":
                                result = (bool)Convert.ChangeType(obj1, typeof(bool)) != (bool)Convert.ChangeType(obj2, typeof(bool));
                                break;
                            case "System.Byte":
                                result = (byte)Convert.ChangeType(obj1, typeof(byte)) != (byte)Convert.ChangeType(obj2, typeof(byte));
                                break;
                            case "System.SByte":
                                result = (sbyte)Convert.ChangeType(obj1, typeof(sbyte)) != (sbyte)Convert.ChangeType(obj2, typeof(sbyte));
                                break;
                            case "System.Char":
                                result = (char)Convert.ChangeType(obj1, typeof(char)) != (char)Convert.ChangeType(obj2, typeof(char));
                                break;
                            case "System.Decimal":
                                result = (decimal)Convert.ChangeType(obj1, typeof(decimal)) != (decimal)Convert.ChangeType(obj2, typeof(decimal));
                                break;
                            case "System.Double":
                                result = (double)Convert.ChangeType(obj1, typeof(double)) != (double)Convert.ChangeType(obj2, typeof(double));
                                break;
                            case "System.Single":
                                result = (Single)Convert.ChangeType(obj1, typeof(Single)) != (Single)Convert.ChangeType(obj2, typeof(Single));
                                break;
                            case "System.Int32":
                                result = (int)Convert.ChangeType(obj1, typeof(int)) != (int)Convert.ChangeType(obj2, typeof(int));
                                break;
                            case "System.UInt32":
                                result = (uint)Convert.ChangeType(obj1, typeof(uint)) != (uint)Convert.ChangeType(obj2, typeof(uint));
                                break;
                            case "System.Int64":
                                result = (long)Convert.ChangeType(obj1, typeof(long)) != (long)Convert.ChangeType(obj2, typeof(long));
                                break;
                            case "System.UInt64":
                                result = (ulong)Convert.ChangeType(obj1, typeof(ulong)) != (ulong)Convert.ChangeType(obj2, typeof(ulong));
                                break;
                            case "System.Int16":
                                result = (short)Convert.ChangeType(obj1, typeof(short)) != (short)Convert.ChangeType(obj2, typeof(short));
                                break;
                            case "System.UInt16":
                                result = (ushort)Convert.ChangeType(obj1, typeof(ushort)) != (ushort)Convert.ChangeType(obj2, typeof(ushort));
                                break;
                            }
                    }
                    break;
                    case FilterType.Greater:
                    {
                        switch (needType)
                        {
                            case "System.String":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Boolean":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Byte":
                                result = (byte)Convert.ChangeType(obj1, typeof(byte)) > (byte)Convert.ChangeType(obj2, typeof(byte));
                                break;
                            case "System.SByte":
                                result = (sbyte)Convert.ChangeType(obj1, typeof(sbyte)) > (sbyte)Convert.ChangeType(obj2, typeof(sbyte));
                                break;
                            case "System.Char":
                                result = (char)Convert.ChangeType(obj1, typeof(char)) > (char)Convert.ChangeType(obj2, typeof(char));
                                break;
                            case "System.Decimal":
                                result = (decimal)Convert.ChangeType(obj1, typeof(decimal)) > (decimal)Convert.ChangeType(obj2, typeof(decimal));
                                break;
                            case "System.Double":
                                result = (double)Convert.ChangeType(obj1, typeof(double)) > (double)Convert.ChangeType(obj2, typeof(double));
                                break;
                            case "System.Single":
                                result = (Single)Convert.ChangeType(obj1, typeof(Single)) > (Single)Convert.ChangeType(obj2, typeof(Single));
                                break;
                            case "System.Int32":
                                result = (int)Convert.ChangeType(obj1, typeof(int)) > (int)Convert.ChangeType(obj2, typeof(int));
                                break;
                            case "System.UInt32":
                                result = (uint)Convert.ChangeType(obj1, typeof(uint)) > (uint)Convert.ChangeType(obj2, typeof(uint));
                                break;
                            case "System.Int64":
                                result = (long)Convert.ChangeType(obj1, typeof(long)) > (long)Convert.ChangeType(obj2, typeof(long));
                                break;
                            case "System.UInt64":
                                result = (ulong)Convert.ChangeType(obj1, typeof(ulong)) > (ulong)Convert.ChangeType(obj2, typeof(ulong));
                                break;
                            case "System.Int16":
                                result = (short)Convert.ChangeType(obj1, typeof(short)) > (short)Convert.ChangeType(obj2, typeof(short));
                                break;
                            case "System.UInt16":
                                result = (ushort)Convert.ChangeType(obj1, typeof(ushort)) > (ushort)Convert.ChangeType(obj2, typeof(ushort));
                                break;
                        }
                    }
                    break;
                    case FilterType.GreaterOrEqual:
                    {
                        switch (needType)
                        {
                            case "System.String":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Boolean":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Byte":
                                result = (byte)Convert.ChangeType(obj1, typeof(byte)) >= (byte)Convert.ChangeType(obj2, typeof(byte));
                                break;
                            case "System.SByte":
                                result = (sbyte)Convert.ChangeType(obj1, typeof(sbyte)) >= (sbyte)Convert.ChangeType(obj2, typeof(sbyte));
                                break;
                            case "System.Char":
                                result = (char)Convert.ChangeType(obj1, typeof(char)) >= (char)Convert.ChangeType(obj2, typeof(char));
                                break;
                            case "System.Decimal":
                                result = (decimal)Convert.ChangeType(obj1, typeof(decimal)) >= (decimal)Convert.ChangeType(obj2, typeof(decimal));
                                break;
                            case "System.Double":
                                result = (double)Convert.ChangeType(obj1, typeof(double)) >= (double)Convert.ChangeType(obj2, typeof(double));
                                break;
                            case "System.Single":
                                result = (Single)Convert.ChangeType(obj1, typeof(Single)) >= (Single)Convert.ChangeType(obj2, typeof(Single));
                                break;
                            case "System.Int32":
                                result = (int)Convert.ChangeType(obj1, typeof(int)) >= (int)Convert.ChangeType(obj2, typeof(int));
                                break;
                            case "System.UInt32":
                                result = (uint)Convert.ChangeType(obj1, typeof(uint)) >= (uint)Convert.ChangeType(obj2, typeof(uint));
                                break;
                            case "System.Int64":
                                result = (long)Convert.ChangeType(obj1, typeof(long)) >= (long)Convert.ChangeType(obj2, typeof(long));
                                break;
                            case "System.UInt64":
                                result = (ulong)Convert.ChangeType(obj1, typeof(ulong)) >= (ulong)Convert.ChangeType(obj2, typeof(ulong));
                                break;
                            case "System.Int16":
                                result = (short)Convert.ChangeType(obj1, typeof(short)) >= (short)Convert.ChangeType(obj2, typeof(short));
                                break;
                            case "System.UInt16":
                                result = (ushort)Convert.ChangeType(obj1, typeof(ushort)) >= (ushort)Convert.ChangeType(obj2, typeof(ushort));
                                break;
                        }
                    }
                    break;
                    case FilterType.Less:
                    {
                        switch (needType)
                        {
                            case "System.String":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Boolean":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Byte":
                                result = (byte)Convert.ChangeType(obj1, typeof(byte)) < (byte)Convert.ChangeType(obj2, typeof(byte));
                                break;
                            case "System.SByte":
                                result = (sbyte)Convert.ChangeType(obj1, typeof(sbyte)) < (sbyte)Convert.ChangeType(obj2, typeof(sbyte));
                                break;
                            case "System.Char":
                                result = (char)Convert.ChangeType(obj1, typeof(char)) < (char)Convert.ChangeType(obj2, typeof(char));
                                break;
                            case "System.Decimal":
                                result = (decimal)Convert.ChangeType(obj1, typeof(decimal)) < (decimal)Convert.ChangeType(obj2, typeof(decimal));
                                break;
                            case "System.Double":
                                result = (double)Convert.ChangeType(obj1, typeof(double)) < (double)Convert.ChangeType(obj2, typeof(double));
                                break;
                            case "System.Single":
                                result = (Single)Convert.ChangeType(obj1, typeof(Single)) < (Single)Convert.ChangeType(obj2, typeof(Single));
                                break;
                            case "System.Int32":
                                result = (int)Convert.ChangeType(obj1, typeof(int)) < (int)Convert.ChangeType(obj2, typeof(int));
                                break;
                            case "System.UInt32":
                                result = (uint)Convert.ChangeType(obj1, typeof(uint)) < (uint)Convert.ChangeType(obj2, typeof(uint));
                                break;
                            case "System.Int64":
                                result = (long)Convert.ChangeType(obj1, typeof(long)) < (long)Convert.ChangeType(obj2, typeof(long));
                                break;
                            case "System.UInt64":
                                result = (ulong)Convert.ChangeType(obj1, typeof(ulong)) < (ulong)Convert.ChangeType(obj2, typeof(ulong));
                                break;
                            case "System.Int16":
                                result = (short)Convert.ChangeType(obj1, typeof(short)) < (short)Convert.ChangeType(obj2, typeof(short));
                                break;
                            case "System.UInt16":
                                result = (ushort)Convert.ChangeType(obj1, typeof(ushort)) < (ushort)Convert.ChangeType(obj2, typeof(ushort));
                                break;
                        }
                    }
                    break;
                    case FilterType.LessOrEqual:
                    {
                        switch (needType)
                        {
                            case "System.String":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Boolean":
                                throw new Exception($"FilterType.Greater String Not Supported");
                                break;
                            case "System.Byte":
                                result = (byte)Convert.ChangeType(obj1, typeof(byte)) <= (byte)Convert.ChangeType(obj2, typeof(byte));
                                break;
                            case "System.SByte":
                                result = (sbyte)Convert.ChangeType(obj1, typeof(sbyte)) <= (sbyte)Convert.ChangeType(obj2, typeof(sbyte));
                                break;
                            case "System.Char":
                                result = (char)Convert.ChangeType(obj1, typeof(char)) <= (char)Convert.ChangeType(obj2, typeof(char));
                                break;
                            case "System.Decimal":
                                result = (decimal)Convert.ChangeType(obj1, typeof(decimal)) <= (decimal)Convert.ChangeType(obj2, typeof(decimal));
                                break;
                            case "System.Double":
                                result = (double)Convert.ChangeType(obj1, typeof(double)) <= (double)Convert.ChangeType(obj2, typeof(double));
                                break;
                            case "System.Single":
                                result = (Single)Convert.ChangeType(obj1, typeof(Single)) <= (Single)Convert.ChangeType(obj2, typeof(Single));
                                break;
                            case "System.Int32":
                                result = (int)Convert.ChangeType(obj1, typeof(int)) <= (int)Convert.ChangeType(obj2, typeof(int));
                                break;
                            case "System.UInt32":
                                result = (uint)Convert.ChangeType(obj1, typeof(uint)) <= (uint)Convert.ChangeType(obj2, typeof(uint));
                                break;
                            case "System.Int64":
                                result = (long)Convert.ChangeType(obj1, typeof(long)) <= (long)Convert.ChangeType(obj2, typeof(long));
                                break;
                            case "System.UInt64":
                                result = (ulong)Convert.ChangeType(obj1, typeof(ulong)) <= (ulong)Convert.ChangeType(obj2, typeof(ulong));
                                break;
                            case "System.Int16":
                                result = (short)Convert.ChangeType(obj1, typeof(short)) <= (short)Convert.ChangeType(obj2, typeof(short));
                                break;
                            case "System.UInt16":
                                result = (ushort)Convert.ChangeType(obj1, typeof(ushort)) <= (ushort)Convert.ChangeType(obj2, typeof(ushort));
                                break;
                        }
                    }
                    break;
                    default: break;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"FilterActor Check Error: {e.Message}");
            }

            return result;
        }
    }
}
