using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace MachinesAndRobotsVKR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
	/// 

    public partial class Model3d : Window
    {

        //public string ConstraintCheck(ProductionLine model)
        //{
        //    string result = "";
        //    if (model.Performance() >= 20)
        //    {
        //        if (model.EnergyConsumption() < 3500)
        //        {
        //            if (model.Square() <= 20)
        //            {
        //                for (int i = 0; i < model.length; i++)
        //                {
        //                    if (model[i].TypeEquipment == "Пневматическое")
        //                    {
        //                        for (int j = 0; j < model.length; j++)
        //                        {
        //                            if (model[i].TypeEquipment == "Компрессор")
        //                            {
        //                                break;
        //                            }
        //                            if (j == model.length)
        //                            {
        //                                result = "Оборудование " + model[i].Name() + " не может выполнять работу без комрессора КП-1";
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                result = "Занимаемая площать промыленной линии превышает допустимое значение!";
        //            }

        //        }
        //        else
        //        {
        //            result = "Энергопотребление производственной линии превышает заданное значение!";
        //        }
        //    }
        //    else
        //    {
        //        result = "Производительность установки не достигает заданного значения!";
        //    }
        //    return result;
        //}



        //private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-8]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}

        //private void Create3DViewPort()
        //{
        //    var hVp3D = new HelixViewport3D();
        //    var lights = new DefaultLights();
        //    var teaPot = new Teapot();
        //    hVp3D.Children.Add(lights);
        //    hVp3D.Children.Add(teaPot);
        //}
        Model3D geom = null; //Debug sphere to check in which point the joint is rotatin
        ModelVisual3D visual;
        ModelVisual3D RoboticArm = new ModelVisual3D();
        List<Joint> joints = new List<Joint>();
        Model3DGroup RA = new Model3DGroup(); //RoboticArm 3d group

        public Model3d(string name)
        {
            InitializeComponent();
            var builder = new MeshBuilder(true, true);
            var position = new Point3D(0, 0, 0);
            geom = new GeometryModel3D(builder.ToMesh(), HelixToolkit.Wpf.Materials.Brown);
            visual = new ModelVisual3D();
            visual.Content = geom;
            viewPort3d.RotateGesture = new MouseGesture(MouseAction.RightClick);
            viewPort3d.PanGesture = new MouseGesture(MouseAction.LeftClick);
            viewPort3d.Children.Add(visual);
            viewPort3d.Children.Add(RoboticArm);
            viewPort3d.Camera.LookDirection = new Vector3D(2038, -5200, -2930);
            viewPort3d.Camera.UpDirection = new Vector3D(-0.145, 0.372, 0.917);
            viewPort3d.Camera.Position = new Point3D(-1571, 4801, 3774);


            ModelImporter import = new ModelImporter();

            var materialGroup = new MaterialGroup();
            //Color mainColor = Colors.White;
            //EmissiveMaterial emissMat = new EmissiveMaterial(new SolidColorBrush(mainColor));
            //DiffuseMaterial diffMat = new DiffuseMaterial(new SolidColorBrush(mainColor));
            //SpecularMaterial specMat = new SpecularMaterial(new SolidColorBrush(mainColor), 200);
            //materialGroup.Children.Add(emissMat);
            //materialGroup.Children.Add(diffMat);
            //materialGroup.Children.Add(specMat);

            var link = import.Load(AppDomain.CurrentDomain.BaseDirectory + "models/" + name);
            GeometryModel3D model = link.Children[0] as GeometryModel3D;
            //model.Material = materialGroup;
            //model.BackMaterial = materialGroup;
            joints.Add(new Joint(link));


            RA.Children.Add(joints[0].model);

            RoboticArm.Content = RA;


            Color cableColor = Colors.DarkSlateGray;

        }

        private void ViewPort3D_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(viewPort3d);
            PointHitTestParameters hitParams = new PointHitTestParameters(mousePos);
            VisualTreeHelper.HitTest(viewPort3d, null, ResultCallback, hitParams);
        }
        public HitTestResultBehavior ResultCallback(HitTestResult result)
        {
            // Did we hit 3D?
            RayHitTestResult rayResult = result as RayHitTestResult;
            if (rayResult != null)
            {
                // Did we hit a MeshGeometry3D?
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;
            }

            return HitTestResultBehavior.Continue;
        }
        private void ViewPort3D_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Perform the hit test on the mouse's position relative to the viewport.
            HitTestResult result = VisualTreeHelper.HitTest(viewPort3d, e.GetPosition(viewPort3d));
            RayMeshGeometry3DHitTestResult mesh_result = result as RayMeshGeometry3DHitTestResult;
        }

    }
}


