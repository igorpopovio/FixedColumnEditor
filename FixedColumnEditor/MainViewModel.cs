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
                "f8c1ba", "acded5", "faeba6",
                "b4d3e8", "f6d2ae", "b3e4c7",
            }.Select(colorHexCode => GetBrushFrom(colorHexCode)).ToList();
        }

        private void InitializeColumnSizes()
        {
            _columnSizes = new List<int>
            {
                9, 15, 7, 5, 21, 21, 21, 21, 6, 4, 7, 6, 9,
                3, 5, 9, 9, 7, 2, 6, 21, 21, 8, 9, 7, 21, 5,
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
