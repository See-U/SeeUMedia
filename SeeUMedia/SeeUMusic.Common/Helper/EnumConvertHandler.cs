using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SeeUMedia.Common.Helper
{
    /// <summary>
    /// 枚举转换处理
    /// </summary>
    public class EnumConvertHandler
    {
        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Tdata"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T StringConvertToEnum<T>(string str)
        {
            T t = default(T);
            try
            {
                t = (T)Enum.Parse(typeof(T), str);
            }
            catch (Exception ex)
            {

                return t;
            }

            return t;

        }

        /// <summary>
        /// 获取枚举数量大小
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetEnumCnt<T>() where T : new()
        {
            T e = new T();
            string[] values = Enum.GetNames(e.GetType());
            var cnt = values.Count();
            return cnt;
        }

        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Type enumType)
        {
            var value = string.Empty;
            object[] objs = enumType.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)//当描述属性没有时，直接返回名称
                return value = "Nall";
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }

        /// <summary>
        /// 获取枚举字段的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumFieldDescription(Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)//当描述属性没有时，直接返回名称
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }

        /// <summary>
        /// 获取枚举字段的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumFieldDescription<T>(T enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)//当描述属性没有时，直接返回空
            {
                value = string.Empty;
                return value;
            }
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }

        /// <summary>
        /// 获取某个枚举的所有字段
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<string> GetEnumAllFieldNames(Type enumType)
        {
            List<string> fieldNameLst = new List<string>();
            FieldInfo[] fieldLst = enumType.GetFields();
            foreach (var field in fieldLst)
            {
                if (!fieldNameLst.Contains(field.Name))
                {
                    fieldNameLst.Add(field.Name);
                }
            }
            return fieldNameLst;
        }
    }
}
