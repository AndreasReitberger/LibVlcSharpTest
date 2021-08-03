using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace RemoteControlRepetierServer.Themes
{
    /// <summary>
    /// Class helps to reduce repetitive markup, and allows an apps appearance to be more easily changed.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalTemplates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalStyles" /> class.
        /// </summary>
		public GlobalTemplates()
        {
            InitializeComponent();
        }
    }
}