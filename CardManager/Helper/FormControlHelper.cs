using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Collections.Specialized;
using Bouwa.Helper;

namespace Bouwa.Helper
{
   public class FormControlHelper
    {

        //public static void BindEnumToComboBox(ComboBox control, Type enumType)
        //{
        //    BindEnumToComboBox(control, enumType, false, false);
        //}

       public static void BindEnumToComboBox(ComboBox control, Type enumType, bool isForSearch)//, bool isOrderByValue
        {
            BindEnumToComboBox(control, enumType, isForSearch, string.Empty);//, isOrderByValue
        }

       public static void BindEnumToComboBox(ComboBox control, Type enumType, bool isForSearch, string defaultValue)//, bool isOrderByValue
        {
            control.DataSource = ConvertEnumToDataTable(enumType, isForSearch);//, isOrderByValue
            //control.DataBind();
           int intTemp=-1;
           if (defaultValue != "")
           {
              intTemp=int.Parse(defaultValue);
           }
           control.ValueMember = "Value";
           control.DisplayMember = "Name";
           control.SelectedValue = intTemp;
        }

        public static void BindDataSourceToComboBox(ComboBox control, object dataSource)
        {
            BindDataSourceToComboBox(control, dataSource, false);
        }

        public static void BindDataSourceToComboBox(ComboBox control, object dataSource, bool isForSearch)
        {
            BindDataSourceToComboBox(control, dataSource, isForSearch, null);
        }

        public static void BindDataSourceToComboBox(ComboBox control, object dataSource, bool isForSearch, string defaultValue)
        {
            control.DataSource = dataSource;
            //control.DataBind();
            if (isForSearch)
            {
                NameValueCollection objNameValueCollection=new NameValueCollection();
                control.Items.Insert(0,"");
            }
            if (defaultValue != null)
            {
                control.SelectedValue = defaultValue;
            }
        }

        public static DataTable ConvertEnumToDataTable(Type enumType, bool isForSearch)//, bool orderByValue
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(int));

            DataRow dr;

            if (isForSearch)
            {
                dr = dt.NewRow();

                dr["Name"] = "全部";//DBNull.Value;
                dr["Value"] = -1;//DBNull.Value;

                dr.EndEdit();
                dt.Rows.Add(dr);
            }

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                dr = dt.NewRow();

                dr["Name"] = enumValue.ToString();
                dr["Value"] = (int)enumValue;

                dr.EndEdit();
                dt.Rows.Add(dr);
            }

            //if (orderByValue)
            //{
            DataView dv = dt.Copy().DefaultView;
            dv.Sort = "Value";
            dt = dv.ToTable();
            //}

            return dt;
        }
    }
}
