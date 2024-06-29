# UC03 - Avaliação - LIST, CRUD, MVC, WINFORMS e BANCO DE DADOS - C#

## Instruções
USE WINFORMS e BANCO DE DADOS

Seu objetivo é criar um programa para ser utilizado como uma lista de tarefas. Onde será possível, criar, listar alterar e deletar uma tarefa. Não esqueça de estruturar como MVC, utilize também a List.
(Seja para trabalho/estudos e dia a dia.)

Vale reforçar que a tarefa deverá conter: o nome da tarefa, a data, a hora. Sempre que criar uma tarefa ela deverá ser marcada como “Não concluída”.
 AO TODO SÃO 4 ATRIBUTOS NO MÍNIMO.

Crie um arquivo chamado readme.md
Nele coloque o comando parar criar a tabela (=
### notes
```sql
--CREATE DATABASE
CREATE DATABASE todoDB;
use todoDB;
-- CREATE TABLE
CREATE TABLE task (
id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR(255) NOT NULL,
data VARCHAR(255) NOT NULL,
hora VARCHAR(255) NOT NULL
);
-- CREATE TESTS
INSERT INTO task (nome, data, hora) VALUES ('Jogar Lixo', '29/06/2024', '13:30');
INSERT INTO task (nome, data, hora) VALUES ('Limpar casa', '30/06/2024', '15:00');
```