# DBGraph

This is the utility project of the client-server system for financial department. 
This utility creates graph based on the structure of database (MS SQL, LINQ to SQL) and allows to automatically generate full SQL query based of SELECT and WHERE blocks. The DBGraph builds connected database graph, where vertices are tables and connections are relations between tables. It allows to automatically fill all blocks for creating correct SQL query (FROM, WHERE, etc.).

When user has chosen all needed blocks (SELECT, aggregate functions, WHERE, conditions in WHERE) the utility will use wave pathfinding alghoritm to find all necessary relations.That relations will extend final SQL query.

<details>
<summary>На русском</summary>  
DBGraph - утилитный модуль, который является частью клиент-серверной системы финансового департамента.
Этот модуль позволяет создавать граф базы данныз (MS SQL с использованием LINQ to SQL) и автоматически генерировать SQL-запрос, основываясь на SELECT и WHERE блоках. Т.к. клиент этого моудял может указать ЧТО он хочет выбрать. В построенном графе таблицы являеются вершинами, а связи между таблицами (ключи) - это связи верщин в графе. Такая система позволяет автоматически заполнять все блоки для формирования корректного SQL-запроса.

Как только пользователь выберет все нужные сблоки (SELECT, агрегатные функции, WHERE, условия) DBGraph запустит расчет на основе волнового алгоритма поиска по графу, чтобы найти все необходимые связи между таблицами. Найденные связи расширят итоговый SQL-запрос
</details>


<h2>Example</h2> 
The user wants to know names of all employees which working on Project "Project A". In addition, the user wants to know their salaries.

User chose in Select block next fields:
- Name of Employee
- Salary

in condition block:
- Project name = "Project A"

The DBGraph will return next connections:

- Employee.id -> Staff.idEmployee
- Staff.idPosition -> Position.id
- ProjectMembers.idPosition -> Position.id
- ProjectMembers.idProject -> Projects.id

And it could be converted to correct SQL query:

<details> 
<summary>На русском</summary>
Пользователь хочет получить информацию обо всех сотрудниках, работающих над проектом "Project A". Дополнительно, пользователь хочет узнать из оклад.

Пользователь выбрал:
- Имя сотрудника
- Оклад

В блоке условий пользователь выбрал:
- Название проекта = "Project A"

Основываясь на этих входных данных, DBGraph вернет следующие связи:

- Employee.id -> Staff.idEmployee
- Staff.idPosition -> Position.id
- ProjectMembers.idPosition -> Position.id
- ProjectMembers.idProject -> Projects.id

Которые могут быть преобразованы в следующий SQL-запрос:
</details>

<i>SELECT Employee.name, Positions.salary<br/>
FROM Employee employee<br/>
INNER JOIN Staff staff ON employee.id = staff.idEmployee<br/>
INNER JOIN Position position ON staff.idPosition = position.id<br/>
INNER JOIN ProjectMembers projectMembers ON projectMembers.idPosition = Position.id<br/>
INNER JOIN Projects projects ON projects.id = projectMembers.idProject<br/>
WHERE projects.name = "Project A"<br/></i>


![image](http://support.anisoprint.com/wp-content/uploads/img/2019-11-09_16-49-59.jpg)
