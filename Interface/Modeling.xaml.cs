using HelixToolkit.Wpf;
using MachinesAndRobotsVKR.Materials;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace MachinesAndRobotsVKR
{
    class Joint
    {
        public Model3D model = null;
        public double angle = 0;
        public double angleMin = -180;
        public double angleMax = 180;
        public int rotPointX = 0;
        public int rotPointY = 0;
        public int rotPointZ = 0;
        public int rotAxisX = 0;
        public int rotAxisY = 0;
        public int rotAxisZ = 0;

        public Joint(Model3D pModel)
        {
            model = pModel;
        }
    }

    public partial class Modeling : Window
    {
        //public double setValueProductivity = 0;
        //public double setValueEnergy = 0;
        //public double setValueSquare = 0;

        string basePath = "";
        bool isRedact = false;
        int idProdLine = 0;
        DB connect = new DB();
        DataTable tableModel = new DataTable();
        ModelVisual3D RoboticArm = new ModelVisual3D();
        Model3D geom = null;
        ModelVisual3D visual;
        public Modeling()
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            basePath = AppDomain.CurrentDomain.BaseDirectory + "models/";
            List<string> listEquipment = new List<string>();
            tableModel = connect.MaterialsEquipment("3D модель");
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

            for (int i = 0; i < tableModel.Rows.Count; i++)
            {
                DataRow row = tableModel.Rows[i];
                listAllEqipment.Items.Add(row["name"]);
            }

            if (listAllEqipment.Items.Count > 0)
                listAllEqipment.SelectedIndex = 0;

        }

        public Modeling(int idProdLine, string nameProductLine)
        {
            InitializeComponent();
            Drag.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            basePath = AppDomain.CurrentDomain.BaseDirectory + "models/";
            List<string> listEquipment = new List<string>();
            tableModel = connect.MaterialsEquipment("3D модель");
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

            for (int i = 0; i < tableModel.Rows.Count; i++)
            {
                DataRow row = tableModel.Rows[i];
                listAllEqipment.Items.Add(row["name"]);
            }

            if (listAllEqipment.Items.Count > 0)
                listAllEqipment.SelectedIndex = 0;

            DataTable Equipment = new DataTable();
            this.idProdLine = idProdLine;
            Equipment = connect.CoordEquipment(idProdLine);
            AddEquipmentInForm(Equipment);
            NameLineBox.Text = nameProductLine;
            isRedact = true;

            for (int i = 0; i < Equipment.Rows.Count; i++)
            {
                DataRow eq = Equipment.Rows[i];

                Productivity += connect.GiveCharacterictic(connect.EquipmentOnMaterial(Convert.ToInt32(eq["idmaterial"])), 10);
                Energy += connect.GiveCharacterictic(connect.EquipmentOnMaterial(Convert.ToInt32(eq["idmaterial"])), 11);
                Square += connect.GiveCharacterictic(connect.EquipmentOnMaterial(Convert.ToInt32(eq["idmaterial"])), 12);
            }
          


            ProdLabel.Content = "Производительность: " + Productivity + " шт/ч";
            EnergeLabel.Content = "Энергопотребление: " + Energy + " Вт";
            SquareLabel.Content = "Занимаемая площадь: " + Square + " м^2";
        }


        private void AddEquipmentInForm(DataTable Equipment)
        {
            for (int i = 0; i < Equipment.Rows.Count; i++)
            {
                if (listAllEqipment.Items.Count > 0)
                {
                    try
                    {
                        ModelImporter import = new ModelImporter();

                        var materialGroup = new MaterialGroup();
                        //Color mainColor = Colors.White;
                        //EmissiveMaterial emissMat = new EmissiveMaterial(new SolidColorBrush(mainColor));
                        //DiffuseMaterial diffMat = new DiffuseMaterial(new SolidColorBrush(mainColor));
                        //SpecularMaterial specMat = new SpecularMaterial(new SolidColorBrush(mainColor), 200);
                        //materialGroup.Children.Add(emissMat);
                        //materialGroup.Children.Add(diffMat);
                        //materialGroup.Children.Add(specMat);
                        DataRow row = Equipment.Rows[i];
                        var link = import.Load(basePath + connect.LinkMaterials((int)row["idmaterial"]));
                        GeometryModel3D model = link.Children[0] as GeometryModel3D;
                        //model.Material = materialGroup;
                        //model.BackMaterial = materialGroup;
                        joints.Add(new Joint(link));
                        RA.Children.Add(joints[numEq].model);
                        joints[numEq].angleMin = -180;
                        joints[numEq].angleMax = 180;
                        joints[numEq].rotAxisX = 0;
                        joints[numEq].rotAxisY = 0;
                        joints[numEq].rotAxisZ = 1;
                        Color cableColor = Colors.DarkSlateGray;
                        Transform3DGroup F1;
                        RotateTransform3D R;
                        F1 = new Transform3DGroup();
                        TranslateTransform3D T;
                        T = new TranslateTransform3D(Convert.ToDouble(row["coordinateX"]), Convert.ToDouble(row["coordinateY"]), Convert.ToDouble(row["coordinateZ"]));
                        F1.Children.Add(T);
                        R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[numEq].rotAxisX, joints[numEq].rotAxisY, joints[numEq].rotAxisZ), (double)row["angle"]));
                        F1.Children.Add(R);
                        joints[numEq].model.Transform = F1; //First joint
                        listAddEqipment.Items.Add(connect.NameMaterials((int)row["idmaterial"]));
                        numEq++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception Error:" + ex.StackTrace);
                    }
                    RoboticArm.Content = RA;
                    changeSelectedJoint();
                }
            }   
        }
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ViewPort3D_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(viewPort3d);
            PointHitTestParameters hitParams = new PointHitTestParameters(mousePos);
            VisualTreeHelper.HitTest(viewPort3d, null, ResultCallback, hitParams);
        }
        public HitTestResultBehavior ResultCallback(HitTestResult result)
        {
            RayHitTestResult rayResult = result as RayHitTestResult;
            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;
            }
            return HitTestResultBehavior.Continue;
        }
        private void ViewPort3D_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(viewPort3d, e.GetPosition(viewPort3d));
            RayMeshGeometry3DHitTestResult mesh_result = result as RayMeshGeometry3DHitTestResult;
        }
        private void rotationPointChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (switchingJoint || listAddEqipment.SelectedIndex < 0)
                return;

            Transform3DGroup F1;
            RotateTransform3D R;
            F1 = new Transform3DGroup();
            TranslateTransform3D T;
            T = new TranslateTransform3D((int)jointX.Value, (int)jointY.Value, (int)jointZ.Value);
            F1.Children.Add(T);
            int sel =  listAddEqipment.SelectedIndex;
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[sel].rotAxisX, joints[sel].rotAxisY, joints[sel].rotAxisZ), joints[sel].angle), new Point3D(joints[sel].rotPointX, joints[sel].rotPointY, joints[sel].rotPointZ));
            F1.Children.Add(R);
            joints[sel].model.Transform = F1;
        }
        public Vector3D ForwardKinematics(int sel, double angles)
        {
            Transform3DGroup F1;
            RotateTransform3D R;
            TranslateTransform3D T;
            F1 = new Transform3DGroup();
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(joints[sel].rotAxisX, joints[sel].rotAxisY, joints[sel].rotAxisZ), angles), new Point3D(joints[sel].rotPointX, joints[sel].rotPointY, joints[sel].rotPointZ));
            F1.Children.Add(R);
            T = new TranslateTransform3D((int)jointX.Value, (int)jointY.Value, (int)jointZ.Value);
            F1.Children.Add(T);
            joints[sel].model.Transform = F1;
            return new Vector3D((int)jointX.Value, (int)jointY.Value, (int)jointZ.Value);
        }

        private void execute_fk(int sel)
        {
            ForwardKinematics(sel, joints[sel].angle);
        }
        private void joint_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (switchingJoint || listAddEqipment.SelectedIndex < 0)
                return;
            int sel = listAddEqipment.SelectedIndex;
            joints[sel].angle = joint1.Value;
            execute_fk(sel);
        }
      
      
        public bool paramX = false;
        public bool paramY = false;
        public bool paramZ = true;
        bool switchingJoint = false;
        private void changeSelectedJoint()
        {
            if (joints == null)
                return;

            int sel = listAddEqipment.SelectedIndex;
            switchingJoint = true;
            unselectModel();
            if (sel < 0)
            {
                jointX.IsEnabled = false;
                jointY.IsEnabled = false;
                jointZ.IsEnabled = false;
                paramX = false;
                paramY = false;
                paramZ = false;
            }
            else
            {
                if (!jointX.IsEnabled)
                {
                    jointX.IsEnabled = true;
                    jointY.IsEnabled = true;
                    jointZ.IsEnabled = true;
                    paramX = true;
                    paramY = true;
                    paramZ = true;
                }
                jointX.Value = joints[sel].rotPointX;
                jointY.Value = joints[sel].rotPointY;
                jointZ.Value = joints[sel].rotPointZ;
                paramX = joints[sel].rotAxisX == 1 ? true : false;
                paramY = joints[sel].rotAxisY == 1 ? true : false;
                paramZ = joints[sel].rotAxisZ == 1 ? true : false;
                selectModel(joints[sel].model);
            }
            switchingJoint = false;
        }

        private void selectModel(Model3D pModel)
        {
            try
            {
                Model3DGroup models = ((Model3DGroup)pModel);
                oldSelectedModel = models.Children[0] as GeometryModel3D;
            }
            catch (Exception)
            {
                oldSelectedModel = (GeometryModel3D)pModel;
            }
            oldColor = changeModelColor(oldSelectedModel, ColorHelper.HexToColor("#ff3333"));
        }


        private void unselectModel()
        {
            changeModelColor(oldSelectedModel, oldColor);
        }
        Color oldColor = Colors.White;
        GeometryModel3D oldSelectedModel = null;
        private Color changeModelColor(GeometryModel3D pModel, Color newColor)
        {
            if (pModel == null)
                return oldColor;

            Color previousColor = Colors.Black;

            MaterialGroup mg = (MaterialGroup)pModel.Material;
            if (mg.Children.Count > 0)
            {
                try
                {
                    previousColor = ((EmissiveMaterial)mg.Children[0]).Color;
                    ((EmissiveMaterial)mg.Children[0]).Color = newColor;
                    ((DiffuseMaterial)mg.Children[1]).Color = newColor;
                }
                catch (Exception)
                {
                    previousColor = oldColor;
                }
            }

            return previousColor;
        }
        double Productivity = 0;
        double Energy = 0;
        double Square = 0;

        public int numEq = 0;
        private void AddInButt_Click(object sender, RoutedEventArgs e)
        {
            if (listAllEqipment.Items.Count > 0)
            {
              
                DataRow row = tableModel.Rows[listAllEqipment.SelectedIndex];
                try
                {
                    ModelImporter import = new ModelImporter();

                    var materialGroup = new MaterialGroup();
                  

                    var link = import.Load(basePath + row["link"]);
                    Productivity += connect.GiveCharacterictic(Convert.ToInt32(row["idequipment"]), 10);
                    Energy += connect.GiveCharacterictic(Convert.ToInt32(row["idequipment"]), 11);
                    Square += connect.GiveCharacterictic(Convert.ToInt32(row["idequipment"]), 12);


                    GeometryModel3D model = link.Children[0] as GeometryModel3D;

                    joints.Add(new Joint(link));

                    RA.Children.Add(joints[numEq].model);
                    joints[numEq].angleMin = -180;
                    joints[numEq].angleMax = 180;
                    joints[numEq].rotAxisX = 0;
                    joints[numEq].rotAxisY = 0;
                    joints[numEq].rotAxisZ = 1;
                    
                    numEq++;
                    Color cableColor = Colors.DarkSlateGray;
                    listAddEqipment.Items.Add(listAllEqipment.SelectedValue);


                    if (setValueSquare > 0 && setValueEnergy > 0 && setValueProductivity > 0)
                    {
                        ProdLabel.Content = "Производительность: " + Productivity + " (задано: " + setValueProductivity + ") шт/ч";
                        EnergeLabel.Content = "Энергопотребление: " + Energy + " (задано: " + setValueEnergy + ") Вт";
                        SquareLabel.Content = "Занимаемая площадь: " + Square + " (задано: " + setValueSquare + ") м^2";
                    }
                    else
                    {
                        ProdLabel.Content = "Производительность: " + Productivity + " шт/ч";
                        EnergeLabel.Content = "Энергопотребление: " + Energy + " Вт";
                        SquareLabel.Content = "Занимаемая площадь: " + Square + " м^2";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Error:" + ex.StackTrace);
                }
                RoboticArm.Content = RA;
                changeSelectedJoint();
            }
        }

        List<Joint> joints = new List<Joint>();
        Model3DGroup RA = new Model3DGroup(); //RoboticArm 3d group
        private void DeleteButt_Click(object sender, RoutedEventArgs e)
        {
            if (listAddEqipment.SelectedIndex>=0)
            {
                int idEquip = connect.GiveIdEq(Convert.ToString(listAddEqipment.SelectedValue));
                RA.Children.RemoveAt(listAddEqipment.SelectedIndex);
                joints.RemoveAt(listAddEqipment.SelectedIndex);
                numEq--;
                listAddEqipment.Items.RemoveAt(listAddEqipment.SelectedIndex);
              
                Productivity -= connect.GiveCharacterictic(idEquip, 10);
                Energy -= connect.GiveCharacterictic(idEquip, 11);
                Square -= connect.GiveCharacterictic(idEquip, 12);

                if (setValueSquare > 0 && setValueEnergy > 0 && setValueProductivity > 0)
                {
                    ProdLabel.Content = "Производительность: " + Productivity + " (задано: " + setValueProductivity + ") шт/ч";
                    EnergeLabel.Content = "Энергопотребление: " + Energy + " (задано: " + setValueEnergy + ") Вт";
                    SquareLabel.Content = "Занимаемая площадь: " + Square + " (задано: " + setValueSquare + ") м^2";
                }
                else
                {
                    ProdLabel.Content = "Производительность: " + Productivity + " шт/ч";
                    EnergeLabel.Content = "Энергопотребление: " + Energy + " Вт";
                    SquareLabel.Content = "Занимаемая площадь: " + Square + " м^2";
                }
            }
        }

        private void listAddEqipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            changeSelectedJoint();
        }
        private void ImgScreenSchots(Grid oScreen, string myUniqueFileName)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)oScreen.ActualWidth-100,
                (int)oScreen.ActualHeight, 60, 60, PixelFormats.Default);
            renderTargetBitmap.Render(oScreen);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using (Stream fileStream = File.Create("preview/"+ myUniqueFileName))
            {
                pngImage.Save(fileStream);
            }
        }

        private bool CheckModel(ref string messege)
        {
            bool errorsFound = false;
            int numFail = 1;
            if(listAddEqipment.Items.Count < 2)
            {
                errorsFound = true;
                messege += numFail++ + ") Производственная линия состоит всего из одного оборудования!\n";
            }
            if (setValueProductivity > 0)
            {
                if (Productivity < setValueProductivity)
                {
                    errorsFound = true;
                    messege += numFail++ + ") Производительность производственной линии меньше заданной! Заменить станок на другой или добавьте ещё один.\n";
                }
                if (Energy > setValueEnergy)
                {
                    errorsFound = true;
                    messege += numFail++ + ") Энергопотребление производственной линии больше заданной! Заменить оборудование на другое или уберите имеющееся.\n";
                }
                if (Square > setValueSquare)
                {
                    errorsFound = true;
                    messege += numFail++ + ") Занимаемая площаль производственной линии больше заданной! Заменить оборудование на другое или уберите имеющееся.\n";
                }
            }
            for (int i = 0; i < listAddEqipment.Items.Count; i++)
            {
               if (listAddEqipment.Items[i].ToString() == "Модель ТУР-10" || listAddEqipment.Items[i].ToString() == "РФ" || listAddEqipment.Items[i].ToString() == "ЦПР")
                {
                    bool checkComp = true;
                    for (int j = 0; j < listAddEqipment.Items.Count; j++)
                    {
                        if(listAddEqipment.Items[j].ToString() == "Компрессор КП-1")
                        {
                            checkComp = false;
                            break;
                        }
                    }
                    if (checkComp)
                    {
                        errorsFound = true;
                        messege += numFail++ + ") Пневматическое оборудование не может выполнять работу без компрессора!\n";
                    }
                }
            }
            for (int i = 0; i < joints.Count; i++)
            {
                if(joints[i].model.Bounds.Location.Z > 30)
                {
                    MessageBoxResult res = MessageBox.Show("Оборудование "+ listAddEqipment.Items[i] + " не может висеть в воздухе!\nИсправить?", "Ошибка!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (res == MessageBoxResult.Yes)
                    {
                        Transform3DGroup F1;
                        RotateTransform3D R;
                        F1 = new Transform3DGroup();
                        TranslateTransform3D T;
                        T = new TranslateTransform3D(joints[i].model.Bounds.Location.X, joints[i].model.Bounds.Location.Y, 0);
                        F1.Children.Add(T);
                        jointZ.Value = 0;
                        int sel = listAddEqipment.SelectedIndex;
                        joints[sel].model.Transform = F1;
                        MessageBox.Show("Координаты оборудования были преобразованы!", "Исправлено", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                
            }


            messege += "Сохранить?";
            return errorsFound;
        }

        private void SaveOrUpdate()
        {
            var myUniqueFileName = $@"{Guid.NewGuid()}.png";
            ImgScreenSchots(GridForVeiw, myUniqueFileName);
            if (isRedact)
            {
                connect.UpdateLine(NameLineBox.Text, Productivity.ToString(), Energy.ToString(), Square.ToString(), myUniqueFileName, idProdLine);
                connect.DeleteEqInLine(idProdLine);
            }
            else
            {
                idProdLine = connect.AddLine(NameLineBox.Text, Productivity.ToString(), Energy.ToString(), Square.ToString(), myUniqueFileName);
            }
            for (int i = 0; i < listAddEqipment.Items.Count; i++)
            {
                connect.AddEqInLine(Convert.ToDouble(joints[i].model.Bounds.Location.X), Convert.ToDouble(joints[i].model.Bounds.Location.Y), Convert.ToDouble(joints[i].model.Bounds.Location.Z), Convert.ToString(listAddEqipment.Items[i]), idProdLine, Convert.ToDouble(joints[i].angle));
            }
        }
        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {
            string messegeError = "";

            if (NameLineBox.Text != "")
            {
                if (CheckModel(ref messegeError))
                {
                    MessageBoxResult res = MessageBox.Show(messegeError, "Рекомендация системы", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (res == MessageBoxResult.Yes)
                    {
                        SaveOrUpdate();
                        MessageBox.Show("Производственная линия успешно сохранена!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
                else
                {
                    SaveOrUpdate();
                    MessageBox.Show("Производственная линия успешно сохранена!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Введите название производственной линии!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        double setValueSquare = 0;
        double setValueProductivity = 0;
        double setValueEnergy = 0;

        private void EnterCharButt_Click(object sender, RoutedEventArgs e)
        {
            ClientFTP.setValueSquare = 0;
            ClientFTP.setValueProductivity = 0;
            ClientFTP.setValueEnergy = 0;
            CriteriaIndicators wm = new CriteriaIndicators();
            wm.ShowDialog();
            MessageBox.Show("Предельные критериальные ограничения добавлены!", "Добавлено!", MessageBoxButton.OK, MessageBoxImage.Information);

            if (ClientFTP.setValueSquare > 0 && ClientFTP.setValueProductivity > 0 && ClientFTP.setValueEnergy > 0)
            {
                setValueSquare = ClientFTP.setValueSquare;
                setValueEnergy = ClientFTP.setValueEnergy;
                setValueProductivity = ClientFTP.setValueProductivity;

                ProdLabel.Content = "Производительность: " + Productivity + " (задано: " + setValueProductivity + ") шт/ч";
                EnergeLabel.Content = "Энергопотребление: " + Energy + " (задано: " + setValueEnergy + ") Вт";
                SquareLabel.Content = "Занимаемая площадь: " + Square + " (задано: " + setValueSquare + ") м^2";
            }

           
        }

        private void HelpButt_Click(object sender, RoutedEventArgs e)
        {          
            MessageBox.Show("В ближайшее время тут появится справочная информация!", "Справка в разработке!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
