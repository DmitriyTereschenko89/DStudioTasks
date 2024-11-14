use [DStudio.Calmplete]

--Напишите запрос, чтобы выбрать всех пользователей с неподтвержденными электронными адресами;
select *
from Users
where EmailConfirmed = 0

update Users
set EmailConfirmed = 0
where UserId in ('4A7B05F2-AA55-45A4-608F-08DBCE615228', '75B0E499-C474-4BAF-560A-08DBCF2153E3', '8DA3C5D5-C608-48DD-560C-08DBCF2153E3')
--Напишите запрос для получения количества пользователей с неподтвержденными письмами;
select count(UserId) as [Number of unverified postal addresses]
from Users
where EmailConfirmed = 0
--Напишите запрос для получения всех незавершенных задач (todos);
select *
from Todos
where IsCompleted = 0
--Напишите запрос, чтобы получить пользователей, у которых есть хотя бы 3 незавершенные задачи.
select u.UserId, u.UserName, u.Email, count(u.UserId) as [Number not completed tasks]
from Users as u
join Todos as td on u.UserId = td.UserId
where td.IsCompleted = 0
group by u.UserId, u.UserName, u.Email

