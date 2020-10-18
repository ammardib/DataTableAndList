using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace DataTableAndList
{
    public static class DataTableAndListConverter
    {
        /// <summary>
        /// Converts List to DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(List<T> _list)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor property in properties)
            {
                table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            foreach (T _row in _list)
            {
                DataRow dataRow = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    dataRow[prop.Name] = prop.GetValue(_row) ?? DBNull.Value;
                }

                table.Rows.Add(dataRow);
            }

            return table;
        }

        /// <summary>
        /// Converts DataTable to List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(DataTable dataTable)
        {
            List<T> list = new List<T>();
            var obj = default(T);
            var type = typeof(T);
            var fields = type.GetProperties();

            foreach (DataRow dr in dataTable.Rows)
            {
                obj = Activator.CreateInstance<T>();
                foreach (var fieldInfo in fields)
                {
                    foreach (DataColumn dc in dataTable.Columns)
                    {
                        if (fieldInfo.Name == dc.ColumnName)
                        {
                            // Get the value from the datatable cell
                            object value = dr[dc.ColumnName];
                            if (value.GetType() == typeof(DBNull))
                                value = null;

                            // Set the value into the object
                            fieldInfo.SetValue(obj, value);
                            break;
                        }
                    }
                }
                if (obj != null)
                    list.Add(obj);
            }

            return list;
        }
    }
}
