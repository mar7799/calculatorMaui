using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class ThemeManager
    {
        public static void SetColorScheme(string scheme)
        {
            if (Application.Current.Resources.TryGetValue($"PrimaryColor{scheme}", out object primaryColor) &&
                Application.Current.Resources.TryGetValue($"SecondaryColor{scheme}", out object secondaryColor) &&
                Application.Current.Resources.TryGetValue($"TextColor{scheme}", out object textColor))
            {
                Application.Current.Resources["PrimaryColor"] = primaryColor;
                Application.Current.Resources["SecondaryColor"] = secondaryColor;
                Application.Current.Resources["TextColor"] = textColor;
            }
        }
    }

}
