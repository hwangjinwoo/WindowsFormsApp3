﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Text = "도서 관리";

            dataGridView1.DataSource = DataManager.Books;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            button1.Click += (sender, e) =>
            {
                try
                {
                    if (DataManager.Books.Exists(x => x.Isbn == textBox1.Text))
                    {
                        MessageBox.Show("이미 존재하는 도서입니다.");
                    }
                    else
                    {
                        Book book = new Book()
                        {
                            Isbn = textBox1.Text,
                            Name = textBox2.Text,
                            Publisher = textBox3.Text,
                            Page = int.Parse(textBox4.Text)
                        };
                        DataManager.Books.Add(book);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Books;
                        DataManager.Save();
                    }
                }
                catch(Exception ex)
                {

                }
            };

            button3.Click += (sender, e) =>
            {
                try
                {

                    Book book = DataManager.Books.Single(x => x.Isbn == textBox1.Text);
                    book.Name = textBox2.Text;
                    book.Publisher = textBox3.Text;
                    book.Page = int.Parse(textBox4.Text);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Books;
                    DataManager.Save();

                }
                catch (Exception ex)
                {

                }
            };
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            { 
                Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
                textBox1.Text = book.Isbn;
            }catch (Exception ex)
            {

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {

            Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
            textBox1.Text = book.Isbn;
            textBox2.Text = book.Name;
            textBox3.Text = book.Publisher;
            textBox4.Text = book.Page.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e) // 삭제
        {
            try
            {

                Book book = DataManager.Books.Single(x => x.Isbn == textBox1.Text);
                DataManager.Books.Remove(book);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Books;
                DataManager.Save();

            }catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e) // 수정
        {
            try
            {
                Book book = DataManager.Books.Single((x) => x.Isbn == textBox1.Text);
                book.Name = textBox2.Text;
                book.Publisher = textBox3.Text;
                book.Page = int.Parse(textBox4.Text);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Books;
                DataManager.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("존재하지 않는 도서입니다.");
            }
        }
    };
}
