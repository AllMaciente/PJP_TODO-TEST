using ModelTask = Model.Task;
using Controller;
using Model;

namespace View;

public class ViewTask : Form
{
    private readonly Label LblName;
    private readonly Label LblDate;
    private readonly Label LblTime;

    private readonly TextBox InpName;
    private readonly TextBox InpDate;
    private readonly TextBox InpTime;


    private readonly Button btnCreate;
    private readonly Button btnAlterar;
    private readonly Button btnDelete;

    private readonly DataGridView dgvPessoas;
    public ViewTask()
    {
        Size = new Size(500, 350);
        MinimumSize = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Todo List";

        LblName = new Label
        {
            Text = "Nome:",
            Location = new Point(25, 25),
            Size = new Size(50, 30)
        };
        LblDate = new Label
        {
            Text = "Data: ",
            Location = new Point(25, 50),
            Size = new Size(50, 30)
        };
        LblTime = new Label
        {
            Text = "Hora: ",
            Location = new Point(25, 75),
            Size = new Size(50, 30)
        };

        InpDate = new TextBox
        {
            Name = "InpData",
            Location = new Point(100, 50),
            Size = new Size(200, 30)
        };
        InpName = new TextBox
        {
            Name = "InpName",
            Location = new Point(100, 25),
            Size = new Size(200, 30)
        };
        InpTime = new TextBox
        {
            Name = "InpTime",
            Location = new Point(100, 75),
            Size = new Size(200, 30)
        };


        btnCreate = new Button
        {
            Text = "Create",
            Location = new Point(325, 25),
            Size = new Size(100, 20)
        };
        // btnCreate.Click += ClickCreate;

        btnAlterar = new Button
        {
            Text = "Alterar",
            Location = new Point(325, 50),
            Size = new Size(100, 20)
        };
        // btnAlterar.Click += ClickAlterar;

        btnDelete = new Button
        {
            Text = "Delete",
            Location = new Point(325, 75),
            Size = new Size(100, 20)
        };
        // btnDelete.Click += ClickDeletar;

        dgvPessoas = new DataGridView
        {
            Location = new Point(30, 125),
            Size = new Size(430, 175)
        };

        Controls.Add(LblDate);
        Controls.Add(LblName);
        Controls.Add(LblTime);

        Controls.Add(InpDate);
        Controls.Add(InpName);
        Controls.Add(InpTime);

        Controls.Add(btnCreate);
        Controls.Add(btnAlterar);
        Controls.Add(btnDelete);

        Controls.Add(dgvPessoas);

        Listar();
    }
    private void Listar()
    {
        List<ModelTask> tasks = ControllerTask.Read();
        dgvPessoas.Columns.Clear();
        dgvPessoas.AutoGenerateColumns = false;
        dgvPessoas.DataSource = tasks;

        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id",
            HeaderText = "Id"
        });
        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Nome",
            HeaderText = "Nome"
        });
        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Data",
            HeaderText = "Data"
        });
        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Hora",
            HeaderText = "Hora"
        });
    }
}