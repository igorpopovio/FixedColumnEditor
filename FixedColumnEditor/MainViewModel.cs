using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            _colors = new[]
            {
                "f3b1cd", "f8d7e8", "bad5f0", "d6eff6", "f8efe6", "fae4cd",
                "f0d5ba", "e3a7c0", "b0abcb", "c2d5a8", "f2e9cc", "a5d5d5",
            }.Select(colorHexCode => GetBrushFrom(colorHexCode)).ToList();
        }

        private void InitializeColumnSizes()
        {
            _columnSizes = new List<int>
            {
                9, 15, 7, 5, 21, 21, 21, 21, 6, 4, 7, 6, 9, 3, 5, 9, 9, 7, 2, 6, 21, 21, 8, 9, 7, 21, 5,
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
