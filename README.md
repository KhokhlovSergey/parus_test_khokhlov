# Тестовое задание Парусник Белгород
Сервис реализует простую систему управления проектами, с хранением в баззе данных PostgreSQL и доступом по средствам RESTAPI интерфейса.

Для работы сервиса необходимо развернуть базу PostgreSQL. В папке проекта, в файле appsettings.json необходимо создать строку подключения с названием "ParusConnection"
Далее, перед первым запуском проекта, необходимо произвести миграцию базы данных, через консоль менеджера пакетов (либо PowerSHell).

Команды add-migration и update-database
# Команды внешнего интерфейса для управления сервисом:
1. Управление проектами
* **Создание проекта**
  
POST запрос 
  `http://localhost:5240/api/ProjectApi/SaveProject`
  
Тело запроса

```    "Id" : 0,
    "Name" : "Названеи проекта",
    "Description" : "Описание проекта"
```
* **Получение списка проектов**
    
GET запрос 
  `http://localhost:5240/api/ProjectApi/GetProjects`

* **Получение информации о проекте**
  
GET запрос 
  `http://localhost:5240/api/ProjectApi/GetProjectById/{id}`

 
* **Изменение информации о проекте**
    
PUT запрос 
  `http://localhost:5240/api/ProjectApi/SaveProject`
  
Тело запроса
```    "Id" : {id},
    "Name" : "Названеи проекта",
    "Description" : "Описание проекта"
```
    
* **Удаление проекта**
  
DELETE запрос 
  `http://localhost:5240/api/ProjectApi/DeleteProject/{id}`

 
* **Добавление пользователя в проект**
    
PUT запрос 
  `http://localhost:5240/api/ProjectApi/UserByProject/add/projectId/{projectId}/userId/{userId}`
  

* **Удаление пользователя из проекта**
    
PUT запрос 
  `http://localhost:5240/api/ProjectApi/UserByProject/del/projectId/{projectId}/userId/{userId}` 


* **Получение списка пользователей, которые работают над проектом**
    
GET запрос 
  `http://localhost:5240/api/UserApi/GetUsersByProject/projectId/{projectId}/str` 

2. Управление задачами в проекте
* **Добавление задачи в проект**
    
PUT запрос 
  `http://localhost:5240/api/ProjectApi/TaskByProject/add/projectId/{projectId}/taskId/{taskId}/string/str` 


* **Изменение задачи в проекте**
    
POST запрос 
  `http://localhost:5240/api/ProjectTaskApi/SaveTask`

Тело запроса
```   "Id" : {id},
    "Name" : "Название задачи",
    "Description" : "Опсиание задачи",
    "Status" : "Статус"
```

* **Удаление задачи из проекта**
    
PUT запрос 
  `http://localhost:5240/api/ProjectApi/TaskByProject/del/projectId/{projectId}/taskId/{taskId}/string/str`

* **Получение списка задач в проекте**
    
GET запрос 
  `http://localhost:5240/api/ProjectTaskApi/GetTaskByProject/projectId/{projectId}` 

* **Получение списка задач в проекте по статусу**
    
GET запрос 
  `http://localhost:5240/api/ProjectTaskApi/GetTaskByStatus/status/{status}`

3. Управление комментариями к задаче
* **Добавление комментария к задаче**
    
POST запрос 
  `http://localhost:5240/api/CommentApi/SaveComment`

Тело запроса

```
{   
    "Id" : 0,
    "Text" : "ТЕкст комментария"
}   
```

* **Изменение комментария к задаче**
    
PUT запрос 
  `http://localhost:5240/api/CommentApi/SaveComment`

Тело запроса

```
{   
    "Id" : {id},
    "Text" : "ТЕкст комментария"
}   
```


* **Удаление комментария к задаче**
  
DELETE запрос 
  `http://localhost:5240/api/CommentApi/DeleteComment/{id}`

 
* **Получение списка комментариев к задаче**
  
GET запрос 
  `http://localhost:5240/api/CommentApi/GetCommentByTask/taskId/{id}`
 
4. Управление пользователями
* **Добавление пользователя**
    
POST запрос 
  `http://localhost:5240/api/UserApi/SaveUser`

Тело запроса

```
{   
    "Id" : 0,
    "Login" : "Redis",
    "Name" : "Денис",
    "Lastname" : "Мартиросов",
    "Email" : "Redis@mail.ru"
} 
```

* **Изменение пользователя**
    
PUT запрос 
  `http://localhost:5240/api/UserApi/SaveUser`

Тело запроса

```
{   
    "Id" : {id},
    "Login" : "Redis",
    "Name" : "Денис",
    "Lastname" : "Мартиросов",
    "Email" : "Redis@mail.ru"
} 
```

* **Удаление пользователя**
  
DELETE запрос 
  `http://localhost:5240/api/UserApi/DeleteUser/{id}`
 
* **Получение списка пользователей**
  
GET запрос 
  `http://localhost:5240/api/UserApi/GetUsers`
 
* **Получение списка пользователей, которые работают над проектом**
  
GET запрос 
  `http://localhost:5240/api/UserApi/GetUsersByProject/projectId/{projectId}/str`
 
* **Получение информации о пользователе**
  
GET запрос 
  `http://localhost:5240/api/UserApi/GetUserById/{id}`
 
