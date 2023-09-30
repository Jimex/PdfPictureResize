using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Security.Cryptography;

namespace PdfPictureResize.Core
{
    public static class ExtendUtils
    {
        public static string ComputeHash(this string data, string hashAlogorithm)
        {
            byte[] bytes = null;
            switch (hashAlogorithm.ToLower())
            {
                case "md5":
                    using (MD5 md5Hash = MD5.Create())
                    {
                        bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                    }
                    break;
                case "sha1":
                    using (SHA1 sha1Hash = SHA1.Create())
                    {
                        bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                    }
                    break;
                case "sha256":
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                    }
                    break;
                case "sha384":
                    using (SHA384 sha384Hash = SHA384.Create())
                    {
                        bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                    }
                    break;
                case "sha512":
                    using (SHA512 sha512Hash = SHA512.Create())
                    {
                        bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                    }
                    break;
            }

            if (bytes.Length > 0)
            {
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
            else return null;
        }

        /// <summary>
        /// Determines if the string contains any of the args. If yes, returns true, otherwise returns false.
        /// </summary>
        /// <param name="instance">The instance of the string</param>
        /// <param name="args">The string to check if contained within the string instance.</param>
        /// <returns>boolean</returns>
        public static bool Contains(this string instance, params string[] args)
        {
            foreach (string s in args)
            {
                if (instance.Contains(s))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Format the string with the args.
        /// </summary>
        public static string FormatWith(this string format, params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(string.Format("The args parameter can not be null when calling {0}.FormatWith().", format));
            }

            return string.Format(format, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            Verify.IsNotNull(format, "format");

            return string.Format(provider, format, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, object source)
        {
            return format.FormatWith(null, source);
        }

       

        public static bool IsNull(this object o)
        {
            return o == null || Convert.IsDBNull(o);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return String.IsNullOrEmpty(s);
        }

        public static bool IsNullOrBlank(this string s)
        {
            return String.IsNullOrWhiteSpace(s);
        }

        public static bool IsNumeric(this string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        public static bool IsInt(this string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

        public static object IfNull(this object o, object defaultValue)
        {
            if (!o.IsNull())
            {
                return o;
            }
            return defaultValue;
        }
        public static string IfNull(this object o, string defaultValue)
        {
            if (!o.IsNull())
            {
                return o.ToString();
            }
            return defaultValue;
        }
        public static bool IfNull(this object o, bool defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            string text = o.ToString();
            if (o is bool)
            {
                return (bool)o;
            }
            bool result;
            if (bool.TryParse(text, out result))
            {
                return result;
            }
            int num;
            if (int.TryParse(text, out num))
            {
                return num != 0;
            }
            return defaultValue;
        }
        public static int IfNull(this object o, int defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is int)
            {
                return (int)o;
            }
            if (o is double || o is decimal)
            {
                return Convert.ToInt32(o);
            }
            string s = o.ToString();
            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static double IfNull(this object o, double defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is double)
            {
                return (double)o;
            }
            string s = o.ToString();
            double result;
            if (double.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static decimal IfNull(this object o, decimal defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is decimal)
            {
                return (decimal)o;
            }
            string s = o.ToString();
            decimal result;
            if (decimal.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static long IfNull(this object o, long defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is long)
            {
                return (long)o;
            }
            if (o is double)
            {
                return Convert.ToInt64(o);
            }
            string s = o.ToString();
            long result;
            if (long.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static ulong IfNull(this object o, ulong defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is ulong)
            {
                return (ulong)o;
            }
            string s = o.ToString();
            ulong result;
            if (ulong.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static uint IfNull(this object o, uint defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is uint)
            {
                return (uint)o;
            }
            string s = o.ToString();
            uint result;
            if (uint.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static DateTime IfNull(this object o, DateTime defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is DateTime)
            {
                return (DateTime)o;
            }
            string s = o.ToString();
            DateTime result;
            if (DateTime.TryParse(s, out result))
            {
                return result;
            }
            return defaultValue;
        }
        public static Enum IfNull(this object o, Enum defaultValue)
        {
            if (o.IsNull())
            {
                return defaultValue;
            }
            if (o is Enum)
            {
                return (Enum)o;
            }
            string text = o.ToString();
            int value;
            object obj;
            if (int.TryParse(text, out value))
            {
                obj = Enum.ToObject(defaultValue.GetType(), value);
            }
            else
            {
                obj = Enum.Parse(defaultValue.GetType(), text, true);
            }
            return (Enum)obj;
        }
        public static string IfNullTrim(this object o)
        {
            if (o.IsNull()) return String.Empty;
            return o.ToString().Trim();
        }
        public static string IfNullTrimEnd(this object o)
        {
            if (o.IsNull()) return String.Empty;
            return o.ToString().TrimEnd();
        }
        #region IfNullOrEmpty

        public static object IfNullOrEmpty(this object o, object defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return o;
        }

        public static string IfNullOrEmpty(this object o, string defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return o.ToString();
        }

        public static bool IfNullOrEmpty(this object o, bool defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            string val = o.ToString();
            bool b;
            if (Boolean.TryParse(val, out b))
                return b;
            int i;
            if (int.TryParse(val, out i))
                return i != 0;
            return Convert.ToBoolean(o);
        }

        public static int IfNullOrEmpty(this object o, int defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToInt32(o);
        }

        public static long IfNullOrEmpty(this object o, long defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToInt64(o);
        }

        public static uint IfNullOrEmpty(this object o, uint defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToUInt32(o);
        }

        public static ulong IfNullOrEmpty(this object o, ulong defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToUInt64(o);
        }

        public static double IfNullOrEmpty(this object o, double defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToDouble(o);
        }

        public static decimal IfNullOrEmpty(this object o, decimal defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToDecimal(o);
        }
        public static DateTime IfNullOrEmpty(this object o, DateTime defaultValue)
        {
            if (o.IsNull()) return IfNull(o, defaultValue);
            if (o.ToString().Trim().Length == 0) return defaultValue;
            return Convert.ToDateTime(o);
        }
        #endregion


        public static string Ellipsis(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static string CleanUpSpaces(this string value)
        {
            return value.Replace("  ", " ").Replace("\n", "").Replace("\r", "").Replace("\t", "");
        }

        public static IEnumerable<string> SplitToLines(this string stringToSplit, int maximumLineLength)
        {
            var words = stringToSplit.Split(' ').Concat(new[] { "" });
            return
                words
                    .Skip(1)
                    .Aggregate(
                        words.Take(1).ToList(),
                        (a, w) =>
                        {
                            var last = a.Last();
                            while (last.Length > maximumLineLength)
                            {
                                a[a.Count() - 1] = last.Substring(0, maximumLineLength);
                                last = last.Substring(maximumLineLength);
                                a.Add(last);
                            }
                            var test = last + " " + w;
                            if (test.Length > maximumLineLength)
                            {
                                a.Add(w);
                            }
                            else
                            {
                                a[a.Count() - 1] = test;
                            }
                            return a;
                        });
        }

        ///<summary>
        ///验证字符串是否有sql注入字段
        ///</summary>
        ///<param name="input"></param>
        ///<returns></returns>
        public static bool IsValidInput(this object objInput)
        {
            try
            {
                if (objInput.IfNullTrim().Length==0)    //字段可为空,修改为返回TRUE
                    return true;
                else
                {
                    string input = objInput.ToString();
                    //替换单引号
                    input = input.Replace("'", "''").Trim();

                    //检测攻击性危险字符串
                    string testString = "and |or |exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
                    string[] testArray = testString.Split('|');
                    foreach (string testStr in testArray)
                    {
                        if (input.ToLower().IndexOf(testStr) != -1)
                        {
                            //检测到攻击字符串,清空传入的值
                            input = "";
                            return false;
                        }
                    }

                    //未检测到攻击字符串
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DataTable To List
        /// </summary>
        /// <typeparam name="TResult">类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<TResult> ToList<TResult>(this DataTable dt) where TResult : class, new()
        {
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            Type t = typeof(TResult);
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            List<TResult> oblist = new List<TResult>();

            foreach (DataRow row in dt.Rows)
            {
                TResult ob = new TResult();
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                oblist.Add(ob);
            }
            return oblist;
        }

  
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }

        public static void AddRange<T, S>(this Dictionary<T, S> source, Dictionary<T, S> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Empty collection");
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
            }
        }


     

        public static string GetHeaderValue(this HttpRequestMessage request, string name)
        {
            IEnumerable<string> headerValues;
            var headerValue = string.Empty;
            if (request.Headers.TryGetValues(name, out headerValues))
            {
                headerValue = headerValues.FirstOrDefault();
            }
            return headerValue;
        }

        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
        //end of class
    }
}
