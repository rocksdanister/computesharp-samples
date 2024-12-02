using D2D1Shader.UWP.Shaders.Runners;
using Windows.UI.Xaml.Controls;

namespace D2D1Shader.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //ApplicationView.PreferredLaunchViewSize = new Size(800, 480);
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            ShaderPanel1.ShaderRunner = new BasicShaderRunner();
        }
    }
}
