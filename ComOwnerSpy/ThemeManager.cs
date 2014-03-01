using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private static SortedDictionary<string, Theme> _themeTable = null;
        private static Theme _currentTheme = null;
        private static readonly string _path = "config\\theme.dat";
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
                AppConfig.CurrentThemeName = _currentTheme.Name;
            }
        }

        private static void CreateDefaultThemes()
        {
            if (_themeTable == null)
                _themeTable = new SortedDictionary<string, Theme>();
            else
                _themeTable.Clear();

            Theme t1 = new Theme("bright color", Color.Black, Color.LightPink, Color.LightGreen, Color.LightGoldenrodYellow, Color.Orange, Color.SkyBlue, SystemColors.Control);
            Theme t2 = new Theme("gray style",
                            Color.FromArgb(10, 10, 10),
                            Color.FromArgb(180, 180, 180),
                            Color.FromArgb(200, 200, 200),
                            Color.FromArgb(215, 215, 215),
                            Color.FromArgb(225, 225, 225),
                            Color.FromArgb(235, 235, 235),
                            SystemColors.Control);

            Theme t3 = new Theme("bright dark",
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

            Theme t5 = new Theme("default",
                           SystemColors.WindowText,
                           SystemColors.Control,
                           SystemColors.Control,
                           SystemColors.Control,
                           SystemColors.Control,
                           SystemColors.Window,
                           SystemColors.Control);

            Theme t6 = new Theme("black & green",
                           Color.FromArgb(0, 255, 0),
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black);

            Theme t7 = new Theme("black & dark green",
                           Color.FromArgb(0, 128, 0),
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black);

            Theme t8 = new Theme("blake & white",
                           Color.White,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black,
                           Color.Black);

            Theme t9 = new Theme("purple & white",
                          Color.White,
                          Color.Purple,
                          Color.Purple,
                          Color.Purple,
                          Color.Purple,
                          Color.Purple,
                          Color.Purple);

            Theme t10 = new Theme("blake & gray",
                         Color.FromArgb(128, 128, 128),
                         Color.Black,
                         Color.Black,
                         Color.Black,
                         Color.Black,
                         Color.Black,
                         Color.Black);

            _themeTable.Add(t1.Name, t1);
            _themeTable.Add(t2.Name, t2);
            _themeTable.Add(t3.Name, t3);
            _themeTable.Add(t4.Name, t4);
            _themeTable.Add(t5.Name, t5);
            _themeTable.Add(t6.Name, t6);
            _themeTable.Add(t7.Name, t7);
            _themeTable.Add(t8.Name, t8);
            _themeTable.Add(t9.Name, t9);
            _themeTable.Add(t10.Name, t10);
        }
        public static void Init()
        {
            LoadThemeFromFile(); 
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

        public static bool Contains(string name)
        {
            return _themeTable.ContainsKey(name);
        }

        public static Theme GetDefaultTheme()
        {
            if (_themeTable == null || _themeTable.Count <= 0)
                return null;

            if (_themeTable.ContainsKey("default"))
                return _themeTable["default"];
            else
                return _themeTable.Values.ElementAt(0);
        }

        public static void RemoveTheme(string name)
        {
            if (_themeTable.ContainsKey(name))
                _themeTable.Remove(name);
        }

        public static void SaveThemeToFile()
        {
            if (_themeTable == null)
                return;

            FileStream fs = null;

            try
            {
                fs = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] verdata = Encoding.UTF8.GetBytes("version=1.0" + System.Environment.NewLine);
                fs.Write(verdata, 0, verdata.Length);

                foreach (Theme theme in _themeTable.Values)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(theme.Name);
                    sb.Append("|");
                    sb.Append(theme.BackColor.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.FontColor.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.ColorA.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.ColorB.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.ColorC.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.ColorD.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.ColorE.ToArgb().ToString());
                    sb.Append("|");
                    sb.Append(theme.Font.ToString());
                    sb.Append(System.Environment.NewLine);
                    byte[] bdata = Encoding.UTF8.GetBytes(sb.ToString());
                    fs.Write(bdata, 0, bdata.Length);
                }
                fs.Flush();
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }

        public static void LoadThemeFromFile()
        {
            string curThemeName = AppConfig.CurrentThemeName;

            if (_themeTable != null)
                _themeTable.Clear();
            else
                _themeTable = new SortedDictionary<string, Theme>();

            StreamReader fs = null;
            /*
            try
            {
                fs = File.OpenText(_path);
                fs.ReadLine(); //version number

               
                while (!fs.EndOfStream)
                {
                    string line = fs.ReadLine();
                    string[] stemp = line.Split(new char[] { '|' });
                    if (stemp.Length >= 9)
                    {
                        Theme theme = new Theme();
                        try
                        {
                            theme.Name = stemp[0];
                            theme.BackColor = Color.FromArgb(int.Parse(stemp[1]));
                            theme.FontColor = Color.FromArgb(int.Parse(stemp[2]));
                            theme.ColorA = Color.FromArgb(int.Parse(stemp[3]));
                            theme.ColorB = Color.FromArgb(int.Parse(stemp[4]));
                            theme.ColorC = Color.FromArgb(int.Parse(stemp[5]));
                            theme.ColorD = Color.FromArgb(int.Parse(stemp[6]));
                            theme.ColorE = Color.FromArgb(int.Parse(stemp[7]));

                            AddTheme(theme);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            catch
            {
                CreateDefaultThemes();
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            */
            if (_themeTable.Count <= 0)
                CreateDefaultThemes();

            if (curThemeName == null)
            {
                curThemeName = "default";
            }

            if (_themeTable.ContainsKey(curThemeName))
                CurrentTheme = _themeTable[curThemeName];
            else if (_themeTable.Count > 0)
                CurrentTheme = _themeTable.Values.ElementAt(0);
            else
                CurrentTheme = null;
        }
    }
}
