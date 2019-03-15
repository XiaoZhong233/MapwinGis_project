﻿using MapWinGis_Demo_zhw.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw.Manager
{
    public static class ComboBoxHelper
    {
        public static IEnumerable<ComboBoxEnumItem<T>> GetComboItems<T>(IEnumerable<T> items) where T : struct, IConvertible
        {
            return items.Select(item => new ComboBoxEnumItem<T>(item, value => value.ToString(CultureInfo.InvariantCulture)));
        }

        public static void AddItemsFromEnum<T>(this ComboBox box) where T : struct, IConvertible
        {
            var t = new T();
            var items = GetComboItems(Enum.GetValues(t.GetType()).OfType<T>());
            foreach (var item in items)
            {
                box.Items.Add(item);
            }
        }

        public static T GetValue<T>(this ComboBox box) where T : struct, IConvertible
        {
            if (box.SelectedItem == null)
            {
                return default(T);
            }

            var item = box.SelectedItem as ComboBoxEnumItem<T>;
            if (item == null)
            {
                throw new InvalidCastException("ComboBoxEnumItem was expected");
            }
            return item.GetValue();
        }

        public static void SetValue<T>(this ComboBox box, T value) where T : struct, IConvertible
        {
            foreach (var item in box.Items)
            {
                var enumItem = item as ComboBoxEnumItem<T>;
                if (enumItem == null)
                {
                    throw new InvalidCastException("ComboBoxEnumItem was expected");
                }
                if (enumItem.GetValue().Equals(value))
                {
                    box.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
