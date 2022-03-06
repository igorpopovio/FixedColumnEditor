using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace FixedColumnOutputInWpf
{
    public class MainViewModel : ViewModel
    {
        private BrushConverter? _brushConverter;
        private List<SolidColorBrush?>? _colors;
        private int _colorIndex;

        private List<int>? _columnSizes;

        public ObservableCollection<ColumnModel>? Columns { get; set; }

        public MainViewModel()
        {
            InitializeColors();
            InitializeColumnSizes();
            GenerateColumns();
        }

        private void InitializeColors()
        {
            _brushConverter = new BrushConverter();
            _colors = new List<SolidColorBrush?>
            {
                GetBrushFrom(colorHexCode: "f3b1cd"),
                GetBrushFrom(colorHexCode: "f8d7e8"),
                GetBrushFrom(colorHexCode: "bad5f0"),
                GetBrushFrom(colorHexCode: "d6eff6"),
                GetBrushFrom(colorHexCode: "f8efe6"),
                GetBrushFrom(colorHexCode: "fae4cd"),

                GetBrushFrom(colorHexCode: "f0d5ba"),
                GetBrushFrom(colorHexCode: "e3a7c0"),
                GetBrushFrom(colorHexCode: "b0abcb"),
                GetBrushFrom(colorHexCode: "c2d5a8"),
                GetBrushFrom(colorHexCode: "f2e9cc"),
                GetBrushFrom(colorHexCode: "a5d5d5"),
            };
        }

        private void InitializeColumnSizes()
        {
            _columnSizes = new List<int>
            {
                9,
                15,
                7,
                5,
                21,
                21,
                21,
                21,
                6,
                4,
                7,
                6,
                9,
                3,
                5,
                9,
                9,
                7,
                2,
                6,
                21,
                21,
                8,
                9,
                7,
                21,
                5,
            };
        }

        private void GenerateColumns()
        {
            Columns = new ObservableCollection<ColumnModel>();
            foreach (var size in _columnSizes)
            {
                var column = new ColumnModel
                {
                    Text = new string(' ', size),
                    Color = _colors[_colorIndex++ % _colors.Count],
                };
                Columns.Add(column);
            }
        }

        private SolidColorBrush? GetBrushFrom(string colorHexCode)
        {
            return _brushConverter.ConvertFrom($"#{colorHexCode}") as SolidColorBrush;
        }
    }
}
