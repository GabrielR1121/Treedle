using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treedle.Model
{
    public partial class Keys : ObservableObject
    {
        public Keys() {

            Color = Color.FromArgb("#787c7f");
            widthreq = 50;
            heightreq = 50;
        }

        [ObservableProperty]
        private string key;

        [ObservableProperty]
        private Color color;

        [ObservableProperty]
        private int widthreq;

        [ObservableProperty]
        private int heightreq;

    }
}
