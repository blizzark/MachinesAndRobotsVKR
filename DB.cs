using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Org.BouncyCastle.Utilities;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using MachinesAndRobotsVKR.Interface;
using static System.Windows.Forms.LinkLabel;
using Org.BouncyCastle.Utilities.Collections;

namespace MachinesAndRobotsVKR
{


    class DB
    {
        private string login { get; set; }
        private string pass { get; set; }
        private string connStr { get; set; }
        private MySqlConnection conn;
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        public DB()
        {

            connStr = "datasource=server42.hosting.reg.ru; user=u1936578; database=u1936578_vkr; password=cS4bA7gK9lwR0gJ0; Charset = utf8;";
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open(); conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутствует соединение с базой! Проверьте доступ к интернету!", "Ошибка!");
            }

        }
        public int GiveIdEq(string nameMaterial)
        {
            conn.Open();
            int value = 0;
            DataTable table = new DataTable();

            string sql = "SELECT material.idequipment FROM u1936578_vkr.material where material.name = @nameMaterial;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("nameMaterial", nameMaterial);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                value = Convert.ToInt32(row[0]);
            }
            conn.Close();
            return value;


        }

        public int GiveIdInst(int id)
        {
            conn.Open();
            int value = 0;
            DataTable table = new DataTable();

            string sql = "SELECT subdivision.idinstitution FROM u1936578_vkr.subdivision where idsubdivision = @id;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("id", id);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                value = Convert.ToInt32(row[0]);
            }
            conn.Close();
            return value;


        }


        public int GiveCharacterictic(double idEq, int character)
        {
            conn.Open();
            int value = 0;
            DataTable table = new DataTable();

            string sql = "SELECT characteristics.value FROM u1936578_vkr.characteristics where equipment_idequipment = @idEq and list_of_characteristics_idcharacteristics = @character;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("idEq", idEq);
            command.Parameters.AddWithValue("character", character);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                value = Convert.ToInt32(row[0]);
            }
            conn.Close();
            return value;


        }

        public int GiveTypeMaterialID(string type)
        {
            conn.Open();
            int value = 0;
            DataTable table = new DataTable();

            string sql = "SELECT material_type.idmaterial_type FROM u1936578_vkr.material_type where name = @type;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("type", type);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                value = Convert.ToInt32(row[0]);
            }
            conn.Close();
            return value;


        }

        public int GiveTypeEquipmentID(string eq)
        {
            conn.Open();
            int value = 0;
            DataTable table = new DataTable();

            string sql = "SELECT equipment.idequipment FROM u1936578_vkr.equipment where name = @eq;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("eq", eq);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                value = Convert.ToInt32(row[0]);
            }
            conn.Close();
            return value;


        }



        public List<string> ProgrammingMethodList(string names) {
            conn.Open();
            List<string> list = new List<string>();

            DataTable table = new DataTable();
            string sql = "SELECT DISTINCT characteristics.value FROM u1936578_vkr.characteristics " +
                "where characteristics.list_of_characteristics_idcharacteristics = " +
                "(select list_of_characteristics.idcharacteristics from list_of_characteristics " +
                "where list_of_characteristics.name = @names); ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("names", names);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[0]));
            }
            conn.Close();
            return list;
        }


        public List<string> EquipmentList(string Subd)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM u1936578_vkr.equipment " +
                "where idsubdivision = ( " +
                "select idsubdivision from u1936578_vkr.subdivision " +
                "where name = @Subd)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("Subd", Subd);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }

        public List<string> EquipmentList()
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM u1936578_vkr.equipment ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }

        public DataTable EquipmentDB(int id)
        {
            conn.Open();
            DataTable table = new DataTable();


            string sql = "SELECT * FROM u1936578_vkr.equipment where idequipment = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            command.Parameters.AddWithValue("id", id);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }

        public List<string> ComboList()
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(sql, conn);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }

        public List<string> ComboListCharac()
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM list_of_characteristics";
            MySqlCommand command = new MySqlCommand(sql, conn);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }


       
      

       
        public DataTable ReturnTabelCharact()
        {
            conn.Open();
            DataTable table = new DataTable();


            string sql = "SELECT characteristics.id, equipment.name as Оборудование, list_of_characteristics.name as Характеристика, characteristics.value as Значение, characteristics.unit as 'Единицы измерения' FROM u1936578_vkr.characteristics " +
                "Inner JOIN equipment ON equipment.idequipment = characteristics.equipment_idequipment " +
                "INNER JOIN list_of_characteristics ON list_of_characteristics.idcharacteristics = characteristics.list_of_characteristics_idcharacteristics; ";
            MySqlCommand command = new MySqlCommand(sql, conn);


            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }

        public DataTable ReturnCharacSearch(string nameEquipment)
        {
            conn.Open();
            DataTable table = new DataTable();


            string sql = "SELECT list_of_characteristics.name AS 'Характеристика оборудования', characteristics.value AS Значение, characteristics.unit as 'Единицы измерения' " +
                "FROM u1936578_vkr.characteristics " +
                "INNER JOIN u1936578_vkr.list_of_characteristics ON characteristics.list_of_characteristics_idcharacteristics = list_of_characteristics.idcharacteristics " +
                "WHERE equipment_idequipment = (SELECT idequipment FROM u1936578_vkr.equipment where equipment.name = @nameEquipment)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("nameEquipment", nameEquipment);

            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }



        public DataTable ReturnTabelEQ()
        {
            conn.Open();
            DataTable table = new DataTable();


            string sql = "SELECT equipment.idequipment, equipment.name as Наименование, subdivision.name as Кафедра, " +
                " user.login as Позьзователь, equipment.date as 'Дата создания' FROM u1936578_vkr.equipment " +
                "Inner JOIN u1936578_vkr.user ON user.iduser = equipment.iduser " +
                "Inner JOIN u1936578_vkr.subdivision ON subdivision.idsubdivision = equipment.idsubdivision; ";
            MySqlCommand command = new MySqlCommand(sql, conn);


            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }


        public DataTable ReturnNameTabels(string nameTabel)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "";
            if (nameTabel == "user")
            {
                sql = "SELECT user.iduser, user.login As 'Логин',user.pass as 'Пароль',user.role as 'Роль' FROM u1936578_vkr.user;";
            }
            if (nameTabel == "list_of_characteristics")
            {
                sql = "SELECT list_of_characteristics.idcharacteristics, list_of_characteristics.name as Название FROM u1936578_vkr.list_of_characteristics;";
            }
            if (nameTabel == "institution")
            {
                sql = "SELECT institution.idinstitution, institution.name as Название FROM u1936578_vkr.institution;";
            }
            if (nameTabel == "subdivision")
            {
                sql = "SELECT subdivision.idsubdivision, subdivision.name as Название FROM u1936578_vkr.subdivision;";
            }
            if (nameTabel == "material")
            {
                sql = "SELECT material.idmaterial, material.name as Название, material.link as 'Путь к материалу', material_type.name as 'Тип материала'," +
                    " equipment.name as Оборудование FROM u1936578_vkr.material inner join u1936578_vkr.material_type on" +
                    " material_type.idmaterial_type = material.idmaterial_type inner join u1936578_vkr.equipment on equipment.idequipment = material.idequipment";
            }





            MySqlCommand command = new MySqlCommand(sql, conn);


            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }

        public DataTable ReturnMaterialsTabelsForEq(int id)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "SELECT material.idmaterial, material.name as Название, material.link as 'Путь к материалу', material_type.name as 'Тип материала'" +
                    " FROM u1936578_vkr.material inner join u1936578_vkr.material_type on" +
                    " material_type.idmaterial_type = material.idmaterial_type where material.idequipment = @id";
            





            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("id", id);

            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }

        public string Description(string equipment)
        {
            conn.Open();
            string description = "";
            DataTable table = new DataTable();
          
            string sql = "SELECT description FROM equipment where name = @equipment";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("equipment", equipment);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                description = Convert.ToString(row[0]);
            }
            conn.Close();
            return description;
        }

        public string LinkMaterials(int idMaterials)
        {
            conn.Open();
            string link = "";
            DataTable table = new DataTable();

            string sql = "SELECT material.link FROM u1936578_vkr.material where idmaterial = @idMaterials";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("idMaterials", idMaterials);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                link = Convert.ToString(row[0]);
            }
            conn.Close();
            return link;
        }

        public string NameMaterials(int idMaterials)
        {
            conn.Open();
            string link = "";
            DataTable table = new DataTable();

            string sql = "SELECT material.name FROM u1936578_vkr.material where idmaterial = @idMaterials";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("idMaterials", idMaterials);

            adapter.SelectCommand = command;
            adapter.Fill(table);


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                link = Convert.ToString(row[0]);
            }
            conn.Close();
            return link;
        }


        public DataTable MaterialsEquipment(string equipment, string material)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();

            string sql = "SELECT material.link, material.name FROM u1936578_vkr.material where idequipment = " +
                "(select idequipment from u1936578_vkr.equipment where equipment.name = @equipment) and" +
                " idmaterial_type = (select idmaterial_type from u1936578_vkr.material_type where material_type.name = @material)";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("equipment", equipment);
            command.Parameters.AddWithValue("material", material);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }





        public DataTable CoordEquipment(int idproduction_line)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();

            string sql = "SELECT * FROM u1936578_vkr.model where idproduction_line " +
                " = (select idproduction_line from u1936578_vkr.production_line where idproduction_line = @idproduction_line);";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("idproduction_line", idproduction_line);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }

        public int EquipmentOnMaterial(int idMaterial)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            int id = 0;
            string sql = "SELECT material.idequipment FROM u1936578_vkr.material where idmaterial = @idMaterial;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("idMaterial", idMaterial);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                id = Convert.ToInt32(row[0]);
            }
            conn.Close();
            return id;
        }

        public DataTable MaterialsEquipment(string material)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();

            string sql = "SELECT material.link, material.name, material.idmaterial, material.idequipment  FROM u1936578_vkr.material where " +
                "idmaterial_type = (select idmaterial_type from u1936578_vkr.material_type where material_type.name = @material)";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("material", material);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }
        public DataTable ListLine()
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM u1936578_vkr.production_line";
            MySqlCommand command = new MySqlCommand(sql, conn);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            return table;
        }

        public List<string> CharactsDB()
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM list_of_characteristics";
            MySqlCommand command = new MySqlCommand(sql, conn);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }


        public List<string> Search(string Characts , string ProgrammingMethod, string Subd)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT equipment.idequipment, equipment.name, characteristics.value, list_of_characteristics.name FROM " +
                "u1936578_vkr.characteristics INNER JOIN u1936578_vkr.equipment ON characteristics.equipment_idequipment = equipment.idequipment " +
                "INNER JOIN u1936578_vkr.list_of_characteristics ON characteristics.list_of_characteristics_idcharacteristics = list_of_characteristics.idcharacteristics " +
                "where (list_of_characteristics.name = @Characts  AND characteristics.value = @ProgrammingMethod) AND equipment.idsubdivision = ( " +
                "select idsubdivision from u1936578_vkr.subdivision where name = @Subd)";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("Characts", Characts);
            command.Parameters.AddWithValue("ProgrammingMethod", ProgrammingMethod);
            command.Parameters.AddWithValue("Subd", Subd);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row["name"]));
            }


            conn.Close();
            return list;
        }

        public List<string> SubdivisionList(string inst)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT subdivision.name FROM u1936578_vkr.subdivision " +
                "where idinstitution = (SELECT institution.idinstitution FROM u1936578_vkr.institution " +
                "where institution.name = @inst); ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("inst", inst);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[0]));
            }
            conn.Close();
            return list;
        }

        public List<string> InstitutionList()
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM institution";
            MySqlCommand command = new MySqlCommand(sql, conn);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }

        public List<string> SubdList()
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            string sql = "SELECT * FROM u1936578_vkr.subdivision";
            MySqlCommand command = new MySqlCommand(sql, conn);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
            }
            conn.Close();
            return list;
        }

        public List<string> CharacteristicsList(string nameEquipment)
        {
            conn.Open();
            List<string> list = new List<string>();
            DataTable table = new DataTable();


            string sql = "SELECT characteristics.equipment_idequipment, characteristics.value, list_of_characteristics.name" +
                " FROM  u1936578_vkr.characteristics " +
                "INNER JOIN u1936578_vkr.list_of_characteristics ON characteristics.list_of_characteristics_idcharacteristics = list_of_characteristics.idcharacteristics" +
                " WHERE equipment_idequipment = ( SELECT idequipment FROM u1936578_vkr.equipment where equipment.name =  @nameEquipment )";

            MySqlCommand commandOne = new MySqlCommand(sql, conn);
            commandOne.Parameters.AddWithValue("nameEquipment", nameEquipment);
            adapter.SelectCommand = commandOne;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                list.Add(Convert.ToString(row[1]));
                list.Add(Convert.ToString(row[2]));
            }
            conn.Close();
            return list;
        }

        public void AddEqsss(string name, string desc, string univer, string path, string lit, string vid, string mod)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.equipment (name, idinstitution, description, iduser, date, image, idvideo, idmodel, idliterature)  " +
                "VALUES(@name, (select idinstitution from u1936578_vkr.educational_institution where name =  @univer ),  @desc, 1, '2020-12-12', @path,  " +
                "(select idvideo from u1936578_vkr.video where name =  @vid),   " +
                "(select id3d from u1936578_vkr.d_model where name = @mod),   " +
                "(select idliterature from u1936578_vkr.literature where name = @lit))";



            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("univer", univer);
            command.Parameters.AddWithValue("desc", desc);
            command.Parameters.AddWithValue("path", path);
            command.Parameters.AddWithValue("vid", vid);
            command.Parameters.AddWithValue("mod", mod);
            command.Parameters.AddWithValue("lit", lit);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }


        public void AddUniver(string univer)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.educational_institution (name) " +
                "VALUES(@univer); ";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("univer", univer);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }

        public void AddCharac(string Charac)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.list_of_characteristics (name) " +
                "VALUES( @Charac); ";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("Charac", Charac);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }

        public void AddCharacAndEq(string Eq, string Charac, string Value, string Unit)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = " INSERT INTO u1936578_vkr.characteristics(equipment_idequipment, list_of_characteristics_idcharacteristics, value, unit) " +
                "VALUES((SELECT idequipment FROM u1936578_vkr.equipment where name = @Eq), " +
                "(SELECT idcharacteristics FROM u1936578_vkr.list_of_characteristics where name = @Charac),  @Value, @Unit) ";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("Eq", Eq);
            command.Parameters.AddWithValue("Charac", Charac);
            command.Parameters.AddWithValue("Value", Value);
            command.Parameters.AddWithValue("Unit", Unit);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }


       


        public void AddPerson(string log, string pass, string role)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.user (login, pass, role) " +
                "VALUES(@log,@pass,@role) ";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("log", log);
            command.Parameters.AddWithValue("pass", pass);
            command.Parameters.AddWithValue("role", role);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }


        public int AddLine(string name, string productivity, string energy, string square, string preview)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.production_line (name, productivity, energy, square, date, preview) " +
                "VALUES(@name,@productivity,@energy, @square, @date, @preview) ";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("productivity", productivity);
            command.Parameters.AddWithValue("energy", energy);
            command.Parameters.AddWithValue("square", square);
            command.Parameters.AddWithValue("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("preview", preview);
            command.ExecuteNonQuery();
            conn.Close();
            return (int)command.LastInsertedId;
        }

        public void UpdateLine(string name, string productivity, string energy, string square, string preview, int idproduction_line)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE production_line SET production_line.name = @name, production_line.productivity = @productivity, " +
                "production_line.energy = @energy, production_line.square = @square, production_line.date = @date, production_line.preview = @preview WHERE production_line.idproduction_line = @idproduction_line";
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("productivity", productivity);
            command2.Parameters.AddWithValue("energy", energy);
            command2.Parameters.AddWithValue("square", square);
            command2.Parameters.AddWithValue("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command2.Parameters.AddWithValue("preview", preview);
            command2.Parameters.AddWithValue("idproduction_line", idproduction_line);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void AddEqInLine(double coordinateX, double coordinateY, double coordinateZ, string nameMateral, int idproduction_line, double angle)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.model (coordinateX, coordinateY, coordinateZ, idmaterial, idproduction_line, angle) VALUES(@coordinateX, @coordinateY, @coordinateZ, " +
                "(SELECT idmaterial FROM u1936578_vkr.material where material.name = @nameMateral), @idproduction_line, @angle)";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("coordinateX", coordinateX);
            command.Parameters.AddWithValue("coordinateY", coordinateY);
            command.Parameters.AddWithValue("coordinateZ", coordinateZ);
            command.Parameters.AddWithValue("nameMateral", nameMateral);
            command.Parameters.AddWithValue("idproduction_line", idproduction_line);
            command.Parameters.AddWithValue("angle", angle);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }

        public void AddSubd(string name, int idInst)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.subdivision(name, idinstitution) VALUES(@name, @idInst)";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("coordinateX", name);
            command.Parameters.AddWithValue("coordinateY", idInst);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }

        public void DeleteEqInLine(int idproduction_line)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "  DELETE FROM u1936578_vkr.model WHERE model.idproduction_line = @idproduction_line; ";
            command2.Parameters.AddWithValue("idproduction_line", idproduction_line);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateEqInLine(double coordinateX, double coordinateY, double coordinateZ, string nameMateral, int idproduction_line, double angle)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "INSERT INTO u1936578_vkr.model (coordinateX, coordinateY, coordinateZ, idmaterial, idproduction_line, angle) VALUES(@coordinateX, @coordinateY, @coordinateZ, " +
                "(SELECT idmaterial FROM u1936578_vkr.material where material.name = @nameMateral), @idproduction_line), @angle)";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("coordinateX", coordinateX);
            command.Parameters.AddWithValue("coordinateY", coordinateY);
            command.Parameters.AddWithValue("coordinateZ", coordinateZ);
            command.Parameters.AddWithValue("nameMateral", nameMateral);
            command.Parameters.AddWithValue("idproduction_line", idproduction_line);
            command.Parameters.AddWithValue("angle", angle);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
        }


        public string Auth(string _login, string _pass)
        {
            conn.Open();
            string sql = "SELECT role FROM user where login = @_login AND pass = @_pass";
            DataTable table = new DataTable();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("_login", _login);
            command.Parameters.AddWithValue("_pass", _pass);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            conn.Close();

            if (table.Rows.Count > 0)
            {
                    DataRow row = table.Rows[0];
                    return Convert.ToString(row[0]);
            }
            else
                return "";
        }

        public void SaveTabelDB(DataTable tabel, string nameTabel)
        {
            conn.Open();
            string sql = "SELECT * FROM @nameTabel";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("nameTabel", nameTabel);
            adapter.SelectCommand = command;
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);
            adapter.Update(tabel);
            conn.Close();
        }


        public string VideoFileName(string equipment)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "SELECT link FROM video " +
                "INNER JOIN u1936578_vkr.equipment " +
                "ON equipment.idvideo = video.idvideo " +
                "where equipment.name = @equipment; ";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("equipment", equipment);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataRow row = table.Rows[0];
            conn.Close();
            return Convert.ToString(row[0]); ;
        }

        public string ModelFileName(string equipment)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "SELECT link FROM d_model INNER JOIN u1936578_vkr.equipment " +
                "ON equipment.idmodel = d_model.id3d" +
                " where equipment.name = @equipment; ";

            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("equipment", equipment);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataRow row = table.Rows[0];
            conn.Close();
            return Convert.ToString(row[0]);
        }


        public string LiteratireFileName(string equipment)
        {
            conn.Open();
            DataTable table = new DataTable();
            string sql = "SELECT link FROM literature" +
                "  INNER JOIN u1936578_vkr.equipment " +
                "ON equipment.idliterature = literature.idliterature" +
                " where equipment.name = @equipment";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("equipment", equipment);
            adapter.SelectCommand = command;
            adapter.Fill(table);
                DataRow row = table.Rows[0];
            conn.Close();
            return Convert.ToString(row[0]); ;
        }

        public void AddMaterial(string name, string path, int typeMaterial, int equipment) 
        {
            conn.Open();
            string sql = "";
            // объект для выполнения SQL-запроса
            MySqlCommand command1 = new MySqlCommand(sql, conn);
            command1.CommandText = "INSERT INTO material (name, link, idmaterial_type, idequipment) VALUES(@name, @path, @typeMaterial, @equipment);";
            command1.Parameters.AddWithValue("name", name);
            command1.Parameters.AddWithValue("path", path);
            command1.Parameters.AddWithValue("typeMaterial", typeMaterial);
            command1.Parameters.AddWithValue("equipment", equipment);
            adapter.SelectCommand = command1;
            int result = command1.ExecuteNonQuery();
            conn.Close();
        }


        public void UpdateMaterial(int idMaterial, string name, string path, int typeMaterial, int equipment)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE  u1936578_vkr.material SET material.name = @name," +
                " material.link = @path, material.idmaterial_type = @typeMaterial, material.idequipment = @equipment WHERE material.idmaterial = @idMaterial";
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("idMaterial", idMaterial);
            command2.Parameters.AddWithValue("path", path);
            command2.Parameters.AddWithValue("typeMaterial", typeMaterial);
            command2.Parameters.AddWithValue("equipment", equipment);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        //public void UpdateModeloRow(int id, string name, string path)
        //{
        //    conn.Open();
        //    string sql = ""; int result = 0;
        //    // объект для выполнения SQL-запроса
        //    MySqlCommand command2 = new MySqlCommand(sql, conn);
        //    command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE d_model SET d_model.name = @name, d_model.link = @path WHERE d_model.id3d = @id";
        //    command2.Parameters.AddWithValue("name", name);
        //    command2.Parameters.AddWithValue("id", id);
        //    command2.Parameters.AddWithValue("path", path);
        //    result = command2.ExecuteNonQuery();
        //    conn.Close();
        //}

        //public void UpdateLitRow(int id, string name, string path)
        //{
        //    conn.Open();
        //    string sql = ""; int result = 0;
        //    // объект для выполнения SQL-запроса
        //    MySqlCommand command2 = new MySqlCommand(sql, conn);
        //    command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE literature SET literature.name = @name, literature.link = @path WHERE literature.idliterature = @id";
        //    command2.Parameters.AddWithValue("name", name);
        //    command2.Parameters.AddWithValue("id", id);
        //    command2.Parameters.AddWithValue("path", path);
        //    result = command2.ExecuteNonQuery();
        //    conn.Close();
        //}


        public void UpdateUserRow(int id, string name, string pass, string role)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE user SET user.login = @name, user.pass = @pass, user.role = @role WHERE user.iduser = @id";
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("id", id);
            command2.Parameters.AddWithValue("pass", pass);
            command2.Parameters.AddWithValue("role", role);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateListCharacRow(int id, string name)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE list_of_characteristics SET list_of_characteristics.name = @name WHERE list_of_characteristics.idcharacteristics = @id";
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("id", id);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateUniverRow(int id, string name)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE institution SET institution.name = @name WHERE institution.idinstitution = @id";
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("id", id);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateSubdRow(int id, string name, int idInst)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0;  UPDATE subdivision SET subdivision.name = @name, subdivision.idinstitution = @idInst WHERE subdivision.idsubdivision = @id";
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("id", id);
            command2.Parameters.AddWithValue("idInst", idInst);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }



        public void UpdateCharacEQRow(int id, string eq, string ch, string val, string unit)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "SET SQL_SAFE_UPDATES = 0; " +
                "UPDATE characteristics SET characteristics.equipment_idequipment = (SELECT idequipment FROM u1936578_vkr.equipment where name = @eq),  " +
                "characteristics.list_of_characteristics_idcharacteristics = (SELECT idcharacteristics FROM u1936578_vkr.list_of_characteristics where name = @ch), " +
                "characteristics.value = @val, characteristics.unit = @unit WHERE characteristics.id = @id";
            command2.Parameters.AddWithValue("id", id);
            command2.Parameters.AddWithValue("eq", eq);
            command2.Parameters.AddWithValue("ch", ch);
            command2.Parameters.AddWithValue("val", val);
            command2.Parameters.AddWithValue("unit", unit);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }


        public void UpdateEQRow(int id, string name, string desc, string img, string univer, string lit, string vid, string mod)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);

            command2.CommandText = "SET SQL_SAFE_UPDATES = 0; " +
               "UPDATE equipment SET equipment.name = @name,  " +
               "equipment.idinstitution = (SELECT idinstitution FROM u1936578_vkr.educational_institution where name = @univer),  " +
               "equipment.description = @desc, equipment.iduser = 1, equipment.date = @date, equipment.image = @path,  " +
               "equipment.idvideo = (SELECT idvideo FROM u1936578_vkr.video where name = @vid),  " +
               "equipment.idliterature = (SELECT idliterature FROM u1936578_vkr.literature where name = @lit),  " +
               "equipment.idmodel = (SELECT id3d FROM u1936578_vkr.d_model where name = @mod) " +
               "WHERE equipment.idequipment = @id";

            command2.Parameters.AddWithValue("id", id);
            command2.Parameters.AddWithValue("name", name);
            command2.Parameters.AddWithValue("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command2.Parameters.AddWithValue("desc", desc);
            command2.Parameters.AddWithValue("univer", univer);
            command2.Parameters.AddWithValue("path", img);
            command2.Parameters.AddWithValue("lit", lit);
            command2.Parameters.AddWithValue("vid", vid);
            command2.Parameters.AddWithValue("mod", mod);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }


        public void DeleteCharac(int id)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "  DELETE FROM characteristics WHERE characteristics.id = @id; ";
            command2.Parameters.AddWithValue("id", id);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }


        public void DeleteProductLine(string name)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = " DELETE FROM production_line WHERE production_line.name = @name; ";
            command2.Parameters.AddWithValue("name", name);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteEQ(int id)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);
            command2.CommandText = "  DELETE FROM equipment WHERE equipment.idequipment = @id; ";
            command2.Parameters.AddWithValue("id", id);
            result = command2.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteNew(int id, string tables)
        {
            conn.Open();
            string sql = ""; int result = 0;
            // объект для выполнения SQL-запроса
            MySqlCommand command2 = new MySqlCommand(sql, conn);

            if (tables == "user")
            {
                command2.CommandText = "  DELETE FROM user WHERE user.iduser = @id; ";
            }
            if (tables == "list_of_characteristics")
            {
                command2.CommandText = "  DELETE FROM list_of_characteristics WHERE list_of_characteristics.idcharacteristics = @id; ";
            }
            if (tables == "educational_institution")
            {
                command2.CommandText = "  DELETE FROM educational_institution WHERE educational_institution.idinstitution = @id; ";
            }
            if (tables == "material")
            {
                command2.CommandText = "  DELETE FROM material WHERE material.idmaterial = @id; ";
            }

            command2.Parameters.AddWithValue("id", id);
            result = command2.ExecuteNonQuery();
            conn.Close();

        }

        public void Close()
        {
            conn.Close();
        }

        ~DB(){
            conn.Close();
        }
    }
}
