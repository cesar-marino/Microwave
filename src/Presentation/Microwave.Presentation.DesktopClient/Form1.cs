using Microwave.Presentation.DesktopClient.Microwave;

namespace Microwave.Presentation.DesktopClient
{
    public partial class Form1 : Form
    {
        private readonly IMicrowaveService _microwaveService;

        public Form1(IMicrowaveService microwaveService)
        {
            _microwaveService = microwaveService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var programs = _microwaveService.GetListPrograms();
        }
    }
}
