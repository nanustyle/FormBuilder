﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
namespace FormBuilder.DataModel
{
    public abstract class ModeBase
    {
    }

    public static class ModeBaseExtension
    {
        public static string ToJason<T>(this ModeBase modeBase, List<T> oList)
        {
            string result;
            if (oList == null || oList.Count == 0)
                return string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(oList, Formatting.None);
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }

        public static string ToJason<T>(this List<T> oList) where T : ModeBase
        {
            string result;
            if (oList == null || oList.Count == 0)
                return string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(oList, Formatting.Indented);
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }

        public static string ToJason(this ModeBase modeBase)
        {
            string result;
            if (modeBase == null)
                return string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(modeBase, Formatting.None);
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }

        public static T ToModeBase<T>(this string data) where T : ModeBase, new()
        {
            T result;
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            try
            {
                result = JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.None,
                        TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                    });
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public static List<T> ToModelBaseObject<T>(this string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }
            List<T> results;
            try
            {
                results = JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            catch (Exception)
            {
                results = null;
            }
            return results;
        }
    }
}
