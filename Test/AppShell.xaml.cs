using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace Test
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void OnLightColorSchemeClicked(object sender, EventArgs e)
        {
            /*ApplyColorScheme(light: true);*/
        }

        private void OnDarkColorSchemeClicked(object sender, EventArgs e)
        {
            /*ApplyColorScheme(dark: true);*/
        }

        private void OnRedColorSchemeClicked(object sender, EventArgs e)
        {
            /* ApplyColorScheme(red: true);*/
        }

        private void OnPinkColorSchemeClicked(object sender, EventArgs e)
        {
            /*ApplyColorScheme(pink: true);*/
        }

        /*private void ApplyColorScheme(bool light = false, bool dark = false, bool red = false, bool pink = false)
        {
            if (light)
            {
                ApplyLightColorScheme();
            }
            else if (dark)
            {
                ApplyDarkColorScheme();
            }
            else if (red)
            {
                ApplyRedColorScheme();
            }
            else if (pink)
            {
                ApplyPinkColorScheme();
            }
        }*/


    }
}