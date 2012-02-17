using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace page_framework
{
    public static class FormPage
    {

        public static void FillInForm<T>(T page, Dictionary<string, string> formData)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty).Where(property => formData.Keys.Contains(property.Name));

            foreach (var field in formData)
            {
                try
                {
                    var property = properties.Single(p => p.Name == field.Key);
                    var converter = TypeDescriptor.GetConverter(property.PropertyType);
                    var value = converter.ConvertFrom(field.Value);
                    property.SetValue(page, value, null);
                }
                catch (Exception)
                {
                    throw new Exception(String.Format("There was a problem with {0} field.", field.Key));
                }
            }
        }

        public static void FillInForm<T>(T page, Dictionary<string, string> formData, Dictionary<string, string> defaultFormData)
        {
            var mergedFormData = MergeFormDataWithDefaults(formData, defaultFormData);
            FillInForm(page, mergedFormData);
        }

        private static Dictionary<string, string> MergeFormDataWithDefaults(Dictionary<string, string> formData, Dictionary<string, string> defaultFormData)
        {
            var mergedFormData = new Dictionary<string, string>(defaultFormData);
            foreach (var field in formData.Keys)
            {
                mergedFormData[field] = formData[field];
            }

            return mergedFormData;
        }

        public static void ValidateFormData<T>(T page, Dictionary<string, string> formData)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty).Where(property => formData.Keys.Contains(property.Name));

            foreach (var field in formData)
            {
                PropertyInfo property;

                try
                {
                    property = properties.Where(p => p.Name == field.Key).Single();
                }
                catch (Exception)
                {
                    throw new Exception(String.Format("There was a problem with {0} field.", field.Key));
                }

                var result = property.GetValue(page, null);

                var converter = TypeDescriptor.GetConverter(property.PropertyType);
                var value = converter.ConvertFrom(field.Value);

                if (property.PropertyType == typeof(string))
                {
                    if (result == null)
                    {
                        Assert.IsTrue(String.IsNullOrEmpty(field.Value));
                        continue;
                    }
                }
                Assert.AreEqual(value, result);
            }
        }

    }
}

