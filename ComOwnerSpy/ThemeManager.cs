using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ComOwnerSpy
{
    public class Theme
    {
        public string Name;
        public Color BackColor = SystemColors.Control;
        public Color ColorA;
        public Color ColorB;
        public Color ColorC;
        public Color ColorD;
        public Color ColorE;
        public Color FontColor = Color.Black;
        public Font  Font = new Font("Microsoft Yahei", 10.0f, FontStyle.Regular);

        public Theme(string name = null)
        {
            Name = name;
        }

        public Theme(string name, Color fontColor, Color colora, Color colorb, Color colorc, Color colord, Color colore, Color backcolor)
        {
            Name = name;
            ColorA = colora;
            ColorB = colorb;
            ColorC = colorc;
            ColorD = colord;
            ColorE = colore;
            BackColor = backcolor;
            FontColor = fontColor;
        }

        public Theme Clone(string name = null)
        {
            Theme t = new Theme(name == null ? (this.Name + "_clone") : name);
            t.ColorA = this.ColorA;
            t.ColorB = this.ColorB;
            t.ColorC = this.ColorC;
            t.ColorD = this.ColorD;
            t.ColorE = this.ColorE;
            t.FontColor = this.FontColor;
            t.Font = this.Font;
            t.BackColor = this.BackColor;

            return t;
        }
    }

    public static class ThemeManager
    {
        private static Dictionary<string, Theme> _themeTable = null;
        private static Theme _currentTheme = null;

        public static Theme CurrentTheme
        {
            get {
                if (_themeTable == null || _themeTable.Count == 0)
                    return null;
                else if (_currentTheme == null)
                    return _themeTable["default"];
                else
                    return _currentTheme;
                    
            }
            set
            {
                _currentTheme = value;
            }
        }
            public static void Init()
        {
            _themeTable = new Dictionary<string, Theme>();
            Theme t1 = new Theme("bright color", Color.Black, Color.LightPink, Color.LightGreen, Color.LightGoldenrodYellow, Color.Orange, Color.SkyBlue, SystemColors.Control);
            Theme t2 = new Theme("gray style",
                            Color.FromArgb(10, 10, 10),
                            Color.FromArgb(180, 180, 180),
                            Color.FromArgb(200, 200, 200),
                            Color.FromArgb(215, 215, 215),
                            Color.FromArgb(225, 225, 225),
                            Color.FromArgb(235, 235, 235),
                            SystemColors.Control);

            Theme t3 = new Theme("default",
                           Color.FromArgb(255, 255, 255),
                           Color.FromArgb(145, 170, 49),
                           Color.FromArgb(77, 183, 154),
                           Color.FromArgb(129, 95, 175),
                           Color.FromArgb(230, 135, 0),
                           Color.FromArgb(44, 95, 140),
                            Color.FromArgb(44, 95, 140));

            Theme t4 = new Theme("metro colorful",
                            Color.FromArgb(255, 255, 255),
                            Color.FromArgb(11, 118, 59),
                            Color.FromArgb(130, 96, 177),
                            Color.FromArgb(105, 0, 63),
                            Color.FromArgb(0, 175, 221),
                            Color.FromArgb(56, 48, 66),
                            Color.FromArgb(56, 48, 66));

                           //SystemColors.Control);

            _themeTable.Add(t1.Name, t1);
            _themeTable.Add(t2.Name, t2);
            _themeTable.Add(t3.Name, t3);
            _themeTable.Add(t4.Name, t4); 
        }

        public static string[] GetAllThemeNames()
        {
            if (_themeTable != null)
                return _themeTable.Keys.ToArray();
            else
                return null;
        }

        public static Theme GetTheme(string name)
        {
            if (_themeTable != null && _themeTable.ContainsKey(name))
                return _themeTable[name];
            else
                return null;
        }
        
        public static void AddTheme(Theme t)
        {
            if (_themeTable.ContainsKey(t.Name))
                return;
            _themeTable.Add(t.Name, t);
        }

        public static void RemoveTheme(Theme t)
        {
            if (_themeTable.ContainsKey(t.Name))
                _themeTable.Remove(t.Name);
        }
    }
}
