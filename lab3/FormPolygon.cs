using System.Windows.Forms;

namespace lab3
{
    public partial class FormPolygon : Form
    {
		public FormPolygon()
        {
            InitializeComponent();

            // Первое задание
            ClassFirst first = new ClassFirst();
            first.drawTask(pbFirst);

            // Второе задание
            ClassSecond second = new ClassSecond();
            second.drawTask(pbSecond);
        }
	}
}