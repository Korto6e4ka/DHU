using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utiltties_project;

namespace Utilities_project
{
    public partial class Form1 : Form
    {
        private object panelAutorization;

        public Form1()
        {
            InitializeComponent();
        }
        private void hide_all_windows()
        {
            panelAutorezation.Visible = false;
            panelMainBuhgalter.Visible = false;
            panelInfoWater.Visible = false;
            panelApartment.Visible = false;
            panelElectricity.Visible = false;
            panelHeat.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM authorization WHERE `Login` = @Login and `Password` = @password", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            cmd.Parameters.AddWithValue("login", textBoxLogin.Text);
            cmd.Parameters.AddWithValue("password", textBoxPassword.Text);
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                hide_all_windows();
                string welcomemsg;
                using (MySqlCommand fetchNames = new MySqlCommand("SELECT * FROM `workers utilities` WHERE `ID`=" + Convert.ToString(table.Rows[0].ItemArray[0])))
                {
                    fetchNames.Connection = conn;
                    fetchNames.CommandType = CommandType.Text;
                    using (DataTable tableNames = new DataTable())
                    {
                        using (MySqlDataAdapter sdaNames = new MySqlDataAdapter(fetchNames))
                        {
                            sdaNames.Fill(tableNames);
                            welcomemsg = "Добро пожаловать, " + Convert.ToString(tableNames.Rows[0].ItemArray[3]) + " " + Convert.ToString(tableNames.Rows[0].ItemArray[2]);
                            labelWorker.Text = Convert.ToString(tableNames.Rows[0].ItemArray[1]) + " " + Convert.ToString(tableNames.Rows[0].ItemArray[3]) + " " + Convert.ToString(tableNames.Rows[0].ItemArray[2]);
                        }
                    }
                }
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
                MessageBox.Show(welcomemsg, "Приветствие", MessageBoxButtons.OK);
                panelAutorezation.Visible = false;
                panelMainBuhgalter.Visible = true;
                panelInfoWater.Visible = false;
                panelApartment.Visible = false;
                panelElectricity.Visible = false;
                panelHeat.Visible = false;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль, пожалуйста, попробуйте снова или обратитесь к администратору", "Ошибка авторизации", MessageBoxButtons.OK);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                hide_all_windows();
                panelAutorezation.Visible = true;
                panelAutorezation.BringToFront();
            }
        }

        private void labelWorker_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.PasswordChar == '*')
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
        }

        private void buttonApartments_Click(object sender, EventArgs e)
        {
            panelAutorezation.Visible = false;
            panelMainBuhgalter.Visible = true;
            panelInfoWater.Visible = false;
            panelApartment.Visible = true;
            panelElectricity.Visible = false;
            panelHeat.Visible = false;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT ID, apartment_number as `Номер квартиры`, floor as `Этаж`, entrance as `Подъезд` FROM apartment", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridViewApartment.DataSource = table;
            dataGridViewApartment.Columns[0].Visible = false;
        }

        private void buttonWater_Click(object sender, EventArgs e)
        {
            panelAutorezation.Visible = false;
            panelMainBuhgalter.Visible = true;
            panelInfoWater.Visible = true;
            panelApartment.Visible = false;
            panelElectricity.Visible = false;
            panelHeat.Visible = false;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT ID_apartment as `Номер квартиры`, hot as `Горячая вода`, cold as `Холодная вода`, date as `Дата заддолжности` FROM `water supply`", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridViewWater.DataSource = table;
        }

        private void buttonHeat_Click(object sender, EventArgs e)
        {
            panelAutorezation.Visible = false;
            panelMainBuhgalter.Visible = true;
            panelInfoWater.Visible = false;
            panelApartment.Visible = false;
            panelElectricity.Visible = false;
            panelHeat.Visible = true;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT ID_apartment as `Номер квартиры`, dedt_amount as `Задолжность`, date as `Дата заддолжности` FROM `heat supply`", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridViewHeat.DataSource = table;
        }

        private void buttonElectricity_Click(object sender, EventArgs e)
        {
            panelAutorezation.Visible = false;
            panelMainBuhgalter.Visible = true;
            panelInfoWater.Visible = false;
            panelApartment.Visible = false;
            panelElectricity.Visible = true;
            panelHeat.Visible = false;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT ID_apartment as `Номер квартиры`, day as `Дневной свет`, night as `Ночной свет`, general  as `Общий`, date as `Дата заддолжности` FROM `electricity supply`", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridViewElectricity.DataSource = table;
        }

        private void dataGridViewApartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridViewApartment.CurrentRow.Cells[0].Value) != "")
            {
                int sum = 0;
                for (int i = 4; i < 10; i++)
                {
                    if (dataGridViewApartment.CurrentRow.Cells[i].Value != DBNull.Value) 
                    {
                        sum += Convert.ToInt16(dataGridViewApartment.CurrentRow.Cells[i].Value);
                    }
                }
                textBoxSum.Text = Convert.ToString(sum);
            }
            else
            {
                textBoxSum.Text = "";
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT apartment.ID as `ID Квартиры`, apartment.apartment_number as `Номер квартиры`, apartment.floor as `Этаж`, apartment.entrance as `Подъезд`, `electricity supply`.`day` as `День`, `electricity supply`.night as `Ночь`, `electricity supply`.general as `Общий`, `heat supply`.dedt_amount as `Долг по отопление`, `water supply`.hot as `Горячая`, `water supply`.cold as `Холодная` FROM apartment LEFT JOIN `electricity supply` ON apartment.ID = `electricity supply`.ID_apartment LEFT JOIN `heat supply` ON apartment.ID = `heat supply`.ID_apartment LEFT JOIN `water supply` ON apartment.ID = `water supply`.ID_apartment WHERE apartment.apartment_number =@number", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            cmd.Parameters.AddWithValue("number", textBoxNumber.Text);
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridViewApartment.DataSource = table;
            dataGridViewApartment.Columns[0].Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT apartment.ID as `ID Квартиры`, apartment.apartment_number as `Номер квартиры`, apartment.floor as `Этаж`, apartment.entrance as `Подъезд`, `electricity supply`.`day` as `День`, `electricity supply`.night as `Ночь`, `electricity supply`.general as `Общий`, `heat supply`.dedt_amount as `Долг по отопление`, `water supply`.hot as `Горячая`, `water supply`.cold as `Холодная` FROM apartment LEFT JOIN `electricity supply` ON apartment.ID = `electricity supply`.ID_apartment LEFT JOIN `heat supply` ON apartment.ID = `heat supply`.ID_apartment LEFT JOIN `water supply` ON apartment.ID = `water supply`.ID_apartment", conn);
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridViewApartment.DataSource = table;
            dataGridViewApartment.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `water supply` (ID_apartment, cold, hot, date) VALUES (@number,@cold,@hot,@date)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("number", textBoxNumberAp.Text);
            cmd.Parameters.AddWithValue("cold", textBoxColdW.Text);
            cmd.Parameters.AddWithValue("hot", textBoxHotW.Text);
            cmd.Parameters.AddWithValue("date", dateTimePickerWater.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            buttonWater.PerformClick();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand clearservices = new MySqlCommand("DELETE FROM `water supply` WHERE ID_apartment = @id", conn);
            clearservices.Parameters.AddWithValue("id", textBoxDelW.Text);
            clearservices.ExecuteNonQuery();
            conn.Close();
            buttonWater.PerformClick();
        }

        private void buttonNewEl_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `electricity supply` (ID_apartment, day, night, general, date) VALUES (@number, @day, @night, @general, @date)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("number", textBoxNewEl.Text);
            cmd.Parameters.AddWithValue("day", textBoxDay.Text);
            cmd.Parameters.AddWithValue("night", textBoxNight.Text);
            cmd.Parameters.AddWithValue("general", textBoxGeneral.Text);
            cmd.Parameters.AddWithValue("date", dateTimePickerEl.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            buttonElectricity.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand clearservices = new MySqlCommand("DELETE FROM `electricity supply` WHERE ID_apartment = @id", conn);
            clearservices.Parameters.AddWithValue("id", textBoxDelEl.Text);
            clearservices.ExecuteNonQuery();
            conn.Close();
            buttonElectricity.PerformClick();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `heat supply` (ID_apartment, dedt_amount, date) VALUES (@number, @dedt_amount, @date)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("number", textBoxNewH.Text);
            cmd.Parameters.AddWithValue("dedt_amount", textBoxDolgH.Text);
            cmd.Parameters.AddWithValue("date", dateTimePickerH.Value);
            cmd.ExecuteNonQuery();
            conn.Close();
            buttonHeat.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            MySqlCommand clearservices = new MySqlCommand("DELETE FROM `heat supply` WHERE ID_apartment = @id", conn);
            clearservices.Parameters.AddWithValue("id", textBoxDelH.Text);
            clearservices.ExecuteNonQuery();
            conn.Close();
            buttonHeat.PerformClick();
        }
    }
}
