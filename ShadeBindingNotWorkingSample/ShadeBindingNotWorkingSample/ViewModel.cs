using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Syncfusion.XForms.Graphics;
using Xamarin.Forms;

namespace ShadeBindingNotWorkingSample
{
    public class ViewModel : ExtendedBindableObject
    {
        public ViewModel()
        {
            InitializeLedColorList();
        }


        private LedColorModel _selecteLed;
        public LedColorModel SelectedLed
        {
            get => _selecteLed;
            set => SetProperty(ref _selecteLed, value);
        }

        private ObservableCollection<LedColorModel> _ledsColorList;

        public ObservableCollection<LedColorModel> LedsColorList
        {
            get => _ledsColorList;
            set => SetProperty(ref _ledsColorList, value);
        }

        private void InitializeLedColorList()
        {
            LedsColorList = new ObservableCollection<LedColorModel>
            {
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.GhostWhite),
                   BackgroundGradient = AddLinearGradient(Colors.SolideWhite, Colors.GhostWhite)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.PastelOrange),
                   BackgroundGradient=AddLinearGradient(Colors.PastelOrange, Colors.FadedOrange)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.LightMustard),
                   BackgroundGradient=AddLinearGradient(Colors.LightMustard, Colors.Maize)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.LightMossGreen),
                   BackgroundGradient=AddLinearGradient(Colors.LightMossGreen, Colors.TanGreen)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.AquaMarineTwo),
                   BackgroundGradient=AddLinearGradient(Colors.AquaMarineTwo, Colors.AquaMarine)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.DarkSkyBlue),
                   BackgroundGradient=AddLinearGradient(Colors.DarkSkyBlue, Colors.DarkSkyBlueTwo)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.Pink),
                   BackgroundGradient=AddLinearGradient(Colors.Pink, Colors.Bubblegum)
               },
               new LedColorModel
               {
                   Color = Color.FromHex(Colors.Liliac),
                   BackgroundGradient=AddLinearGradient(Colors.Liliac, Colors.Periwinkle)
               }
            };

            SelectedLed = LedsColorList.FirstOrDefault();
        }

        private SfLinearGradientBrush AddLinearGradient(string color1, string color2)
        {
            SfLinearGradientBrush gradient = new SfLinearGradientBrush();

            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 1);

            gradient.GradientStops.Add(new SfGradientStop { Color = Color.FromHex(color1), Offset = 0 });
            gradient.GradientStops.Add(new SfGradientStop { Color = Color.FromHex(color1), Offset = 0.5 });
            gradient.GradientStops.Add(new SfGradientStop { Color = Color.FromHex(color2), Offset = 0.5 });
            gradient.GradientStops.Add(new SfGradientStop { Color = Color.FromHex(color2), Offset = 1 });
            return gradient;
        }
    }

    public class LedColorModel : ExtendedBindableObject
    {
        public SfLinearGradientBrush BackgroundGradient { get; set; }
        //public Color Color { get; set; }

        private Color _color;
        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
    }

    public abstract class ExtendedBindableObject : BindableObject
    {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body is UnaryExpression)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }

    public static class Colors
    {
        public const string White = "#FFFFFF";
        public const string BondiBlue = "#02A6B6";
        public const string Fiord = "#4A6170";
        public const string GhostWhite = "#F1F1F2";
        public const string Gainsboro = "#DDDDDE";
        public const string YellowGreen = "#AFE787";
        public const string Turquoise = "#50E3C2";
        public const string BlueRaspberry = "#29D3E8";
        public const string SpanishViolet = "#4b3371";
        public const string Lavender = "#b271e6";
        public const string Water = "#D9F6FF";
        public const string MangoTango = "#FA8138";
        public const string SlateGray = "#657F91";
        public const string SolideWhite = "#f7f7f7";
        public const string FadedOrange = "#f89347";
        public const string PastelOrange = "#ff9955";
        public const string LightMustard = "#ffcf55";
        public const string Maize = "#f9c748";
        public const string LightMossGreen = "#a0d468";
        public const string TanGreen = "#98cd5f";
        public const string AquaMarineTwo = "#48cfae";
        public const string AquaMarine = "#38c8a5";
        public const string DarkSkyBlueTwo = "#41b9e4";
        public const string DarkSkyBlue = "#4fc0e8";
        public const string Pink = "#ec88c0";
        public const string Bubblegum = "#ed7cbb";
        public const string Liliac = "#ac91f2";
        public const string Periwinkle = "#a689f2";
        public const string PictonBlueSemiTransparent = "#804cb4f6";
    }
}